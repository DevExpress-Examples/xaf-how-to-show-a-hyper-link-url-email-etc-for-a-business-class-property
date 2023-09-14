<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128593398/23.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2096)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [WinHyperLinkStringPropertyEditor.cs](./CS/EFCore/HyperLinkEditorEF/HyperLinkEditorEF.Win/Editors/WinHyperLinkStringPropertyEditor.cs) 
* [BlazorHyperLinkPropertyEditor](./CS/EFCore/HyperLinkEditorEF/HyperLinkEditorEF.Blazor.Server/Editors/HyperLinkPropertyEditor) 
<!-- default file list end -->
# How to show a hyper link (URL, email, etc.) for a business class property

 This example shows custom [Property Editors](https://docs.devexpress.com/eXpressAppFramework/113097/ui-construction/view-items-and-property-editors/property-editors) for WinForms and Blazor platforms that represents object fields containing email address or URL as clickable text in the UI.

To validate an url, these editors use a combined RexEx mask. The default regular expression is the following:
(((http|https|ftp)\://)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})

You can use it as is or modify it per your specific needs. Look for [Regular Expression](https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference) in MSDN for more information on how to do this.
For end-users convenience, in DetailView of WinForms projects, a double-click is necessary to open an URL.

These editors are created for learning purposes only. Feel free to extend it further or create your own editors to meet all your business needs.

![image](https://user-images.githubusercontent.com/14300209/227552053-d0e508b7-832c-4579-934d-2624ca8de589.png)
