﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DVDA.Contracts.Transform
{
    public enum FieldTypes
    {
        [Display(Name = "TextField")]
        Text = 1,
        [Display(Name = "RichTextField")]
        RichText = 2,
        [Display(Name = "BooleanField")]
        Boolean = 3,
        [Display(Name = "DateTimeField")]
        Date = 4,
        [Display(Name = "ItemField")]
        Item = 5,
        [Display(Name = "NestedItemField")]
        NestedItem = 6,
        [Display(Name = "NumberField")]
        Number = 7,
        [Display(Name = "SingleListField")]
        Array = 8,
        [Display(Name = "ItemCollectionField")]
        ItemCollection = 9
    }
}
