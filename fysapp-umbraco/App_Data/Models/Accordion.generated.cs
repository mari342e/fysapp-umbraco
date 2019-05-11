//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.10.102
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace Umbraco.Web.PublishedContentModels
{
	/// <summary>Accordion</summary>
	[PublishedContentModel("accordion")]
	public partial class Accordion : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "accordion";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Accordion(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Accordion, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Tekst
		///</summary>
		[ImplementPropertyType("Text")]
		public IHtmlString Text
		{
			get { return this.GetPropertyValue<IHtmlString>("Text"); }
		}

		///<summary>
		/// Titel
		///</summary>
		[ImplementPropertyType("Title")]
		public string Title
		{
			get { return this.GetPropertyValue<string>("Title"); }
		}

		///<summary>
		/// Brugergruppe ID
		///</summary>
		[ImplementPropertyType("UserGroupID")]
		public int UserGroupID
		{
			get { return this.GetPropertyValue<int>("UserGroupID"); }
		}
	}
}
