using System;
using System.Collections.Generic;
using System.Configuration;
using Common.Services;
using DD4T.ContentModel.Contracts.Resolvers;
using DD4T.ContentModel.Factories;
using DD4T.Core.Contracts.ViewModels;
using DD4T.Providers.SDLWeb8.CIL;
using System.Runtime.Caching;
using Core.Models;

namespace Core.Services
{
    public class LabelService : ILabelService
    {
        protected IPublicationResolver PublicationResolver { get; set; }
        protected IComponentPresentationFactory ComponentPresentationFactory { get; set; }
        protected IViewModelFactory ViewModelFactory { get; set; }

        public LabelService(IPublicationResolver publicationResolver, IComponentPresentationFactory componentPresentationFactory, IViewModelFactory viewModelFactory)
        {
            PublicationResolver = publicationResolver;
            ComponentPresentationFactory = componentPresentationFactory;
            ViewModelFactory = viewModelFactory;
        }

        protected Dictionary<string, string> Labels
        {
            get
            {
                var labels = (Dictionary<string, string>)MemoryCache.Default[Constants.LabelsCacheKey];

                if (labels == null)
                {
                    labels = new Dictionary<string, string>();

                    var publicationId = PublicationResolver.ResolvePublicationId();

                    var query = new ExtendedQueryParameters
                    {
                        PublicationId = publicationId
                    };

                    var labelsSchemaId = string.Format(ConfigurationManager.AppSettings[Constants.LabelSetSchemaIdAppSettingKey], publicationId);
                    query.QuerySchemas = new[] { labelsSchemaId };

                    var cps = ComponentPresentationFactory.FindComponentPresentations(query);

                    foreach (var cp in cps)
                    {
                        var model = ViewModelFactory.BuildViewModel<LabelSet>(cp);

                        foreach (var label in model.Labels)
                        {
                            var compositeKey = $"{model.ComponentTitle}.{label.Key}";

                            if (!labels.ContainsKey(compositeKey))
                            {
                                labels.Add(compositeKey, label.Value);
                            }
                        }
                    }

                    int cacheDuration;
                    if (int.TryParse(ConfigurationManager.AppSettings[Constants.LabelsCacheDurationAppSettingKey], out cacheDuration))
                    {
                        var offset = new DateTimeOffset(DateTime.UtcNow.AddSeconds(cacheDuration));

                        MemoryCache.Default.Add(Constants.LabelsCacheKey, labels, offset);
                    }
                }

                return labels;
            }
        }

        public bool TryGetLabel(string key, out string value)
        {
            value = key;

            if (Labels.ContainsKey(key))
            {
                value = Labels[key];

                return true;
            }

            return false;
        }
    }
}
