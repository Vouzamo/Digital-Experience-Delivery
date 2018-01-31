using CMS.Delivery.Models;
using CMS.Delivery.Providers.DD4T.Models;
using DD4TModels = DD4T.ContentModel;
using Refit;
using System;
using System.Collections.Generic;
using DD4T.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CMS.Delivery.Providers.DD4T
{
    public class DD4TCompositionProvider : ICompositionProvider
    {
        public Guid Id => new Guid("3253b2df-9b21-4a08-b4a3-969f257694a0");

        private IIdentityManager IdentityManager { get; set; }
        private IDD4TContract Client { get; set; }

        public DD4TCompositionProvider(IIdentityManager identityManager)
        {
            IdentityManager = identityManager;
            Client = RestService.For<IDD4TContract>("http://dd4t.samplesite.com");
        }

        public IComposition GetComposition(IContext context)
        {
            try
            {
                var pageJson = Client.GetPage(context).Result;

                var serializer = new JSONSerializerService();

                var pageDD4T = JsonConvert.DeserializeObject<Page>(pageJson);

                var page = serializer.Deserialize<DD4TModels.Page>(pageJson);

                return ConvertPageToComposition(page, pageDD4T, context);
            }
            catch(Exception ex)
            {
                throw new KeyNotFoundException("Couldn't find the requested composition");
            }
        }

        private IComposition ConvertPageToComposition(DD4TModels.IPage page, Page pageDD4T, IContext context)
        {
            var pageId = IdentityManager.ToFrameworkId(this, page.Id.ToString());

            var pageTemplate = ConvertPageTemplate(page.PageTemplate);

            var composition = new Composition(pageId, pageTemplate);

            var cps = new List<DD4TModels.ComponentPresentation>();

            var index = 0;
            foreach(var cp in page.ComponentPresentations)
            {
                var targetGroupConditions = pageDD4T?.ComponentPresentations[index]?.TargetGroupConditions;
                if (targetGroupConditions == null || EvaluateTargetGroupConditions(targetGroupConditions, context))
                {
                    var content = ConvertComponent(cp.Component);
                    var template = ConvertComponentTemplate(cp.ComponentTemplate);

                    composition.AddRendering(new Rendering(content, template));
                }

                index += 1;
            }

            return composition;
        }

        private bool EvaluateTargetGroupConditions(List<TargetGroupCondition> targetGroupConditions, IContext context)
        {
            try
            {
                var evaluation = true;

                foreach (var targetGroupCondition in targetGroupConditions)
                {
                    var targetGroup = targetGroupCondition.TargetGroup;

                    var result = EvaluateConditions(targetGroup.Conditions, context);

                    result = targetGroupCondition.Negate ? !(result) : result;

                    evaluation = evaluation && result;
                }

                return evaluation;
            }
            catch(Exception ex)
            {
                return true;
            }
        }

        private bool EvaluateConditions(List<CustomerCharacteristicCondition> conditions, IContext context)
        {
            var evaluation = true;

            IDictionary<string, string> claims = ConvertContextToClaims(context);

            foreach(var condition in conditions)
            {
                bool result = false;

                if (claims.TryGetValue(condition.Name.ToLowerInvariant(), out string value))
                {
                    switch (condition.Operator)
                    {
                        case Operators.Equals:
                            result = condition.Value.Equals(value);
                            break;
                        case Operators.GreaterThan:
                            result = int.Parse(value) > int.Parse(condition.Value);
                            break;
                        case Operators.LessThan:
                            result = int.Parse(value) < int.Parse(condition.Value);
                            break;
                        case Operators.NotEqual:
                            result = !condition.Value.Equals(value);
                            break;
                        case Operators.StringEquals:
                            result = condition.Value.ToString().Equals(value);
                            break;
                        case Operators.Contains:
                            result = value.Contains(condition.Value.ToString());
                            break;
                        case Operators.StartsWith:
                            result = value.StartsWith(condition.Value.ToString());
                            break;
                        case Operators.EndsWith:
                            result = value.EndsWith(condition.Value.ToString());
                            break;
                        default:
                            result = false;
                            break;
                    }

                    result = condition.Negate ? !(result) : result;
                }

                evaluation = evaluation && result;
            }

            return evaluation;
        }

        private IDictionary<string, string> ConvertContextToClaims(IContext context)
        {
            var claims = new Dictionary<string, string>();

            var json = JsonConvert.SerializeObject(context);

            var jObject = JsonConvert.DeserializeObject<JObject>(json);

            foreach(var prop in jObject.Properties())
            {
                var key = prop.Name.ToLowerInvariant();

                claims.TryAdd(prop.Name.ToLowerInvariant(), prop.Value.ToString());
            }

            return claims;
        }

        private IContent ConvertComponent(DD4TModels.IComponent component)
        {
            var id = IdentityManager.ToFrameworkId(this, component.Id.ToString());

            // Component fields
            var data = string.Empty;

            return new Content(id, data);
        }

        private Delivery.Models.ITemplate ConvertComponentTemplate(DD4TModels.IComponentTemplate componentTemplate)
        {
            var id = IdentityManager.ToFrameworkId(this, componentTemplate.Id.ToString());

            // Component Template Metadata fields
            var data = string.Empty;

            return new Template(id, data);
        }

        private Delivery.Models.ITemplate ConvertPageTemplate(DD4TModels.IPageTemplate pageTemplate)
        {
            var id = IdentityManager.ToFrameworkId(this, pageTemplate.Id.ToString());

            // Page Template Metadata fields
            var data = "{\"View\":\"Default\"}";

            return new Template(id, data);
        }
    }
}
