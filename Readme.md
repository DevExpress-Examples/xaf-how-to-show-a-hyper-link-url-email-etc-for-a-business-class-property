<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128593398/23.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2096)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# XAF - How to show a hyper link (URL, email, etc.) for a business class property

 This example shows custom [Property Editors](https://docs.devexpress.com/eXpressAppFramework/113097/ui-construction/view-items-and-property-editors/property-editors) that provide access to object fields with an email address or URL as clickable text.

To validate a URL, these editors use a combined `RexEx` mask. The default regular expression is:

```
(((http|https|ftp)\://)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})
```

You can use it as is or modify it per your specific needs. Search for [Regular Expression](https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference) in MSDN for more information on how to do this.
A double click opens a URL in DetailView of the WinForms project for end-user convenience.

These editors are created for learning purposes only. You can extend them or create your own editors to meet your business needs.

<kbd>![image](https://user-images.githubusercontent.com/14300209/227552053-d0e508b7-832c-4579-934d-2624ca8de589.png)</kbd>

## Files to Review

* [WinHyperLinkStringPropertyEditor.cs](./CS/EFCore/HyperLinkEditorEF/HyperLinkEditorEF.Win/Editors/WinHyperLinkStringPropertyEditor.cs) 
* [BlazorHyperLinkPropertyEditor](./CS/EFCore/HyperLinkEditorEF/HyperLinkEditorEF.Blazor.Server/Editors/HyperLinkPropertyEditor)

## Documentation

* [Property Editors](https://docs.devexpress.com/eXpressAppFramework/113097/ui-construction/view-items-and-property-editors/property-editors)
* [Customize a Built-in Property Editor (Blazor)](https://docs.devexpress.com/eXpressAppFramework/402188/ui-construction/view-items-and-property-editors/property-editors/customize-a-built-in-property-editor-blazor)
* [Implement a Property Editor Based on a Custom Component (Blazor)](https://docs.devexpress.com/eXpressAppFramework/402189/ui-construction/view-items-and-property-editors/property-editors/implement-a-property-editor-based-on-custom-components-blazor)

## More Examples

* [How to: Display an Integer Property as an Enumeration](https://github.com/DevExpress-Examples/XAF_how-to-display-an-integer-property-as-an-enumeration-e4925)
* [How to: Disable Property Editors Based on a Business Rule](https://github.com/DevExpress-Examples/XAF_how-to-disable-property-editors-based-on-a-business-rule-e1672)
