using ProjectService.DatacontextRep;
using ProjectService.InterfaceRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAuthen.Uilti
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        private ILocalizationRep _localizationService = new LocalizationRep();
        private Localizer _localizer;

        /// <summary>
        /// Get a localized resources
        /// </summary>
        public Localizer T
        {
            get
            {
                if (_localizer == null)
                {
                    //default localizer
                    _localizer = (format, args) =>
                    {
                        var resFormat = _localizationService.GetResources(format, "vi");
                        if (string.IsNullOrEmpty(resFormat))
                        {
                            return new LocalizedString(format);
                        }
                        return
                            new LocalizedString((args == null || args.Length == 0)
                                                    ? resFormat
                                                    : string.Format(resFormat, args));
                    };
                }
                return _localizer;
            }
        }
    }
    /// <summary>
    /// Web view page
    /// </summary>
    public abstract class WebViewPage : WebViewPage<dynamic>
    {
    }
}