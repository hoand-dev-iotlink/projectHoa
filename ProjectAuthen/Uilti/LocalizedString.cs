﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAuthen.Uilti
{
    public class LocalizedString : MarshalByRefObject, IHtmlString
    {
        private readonly string _localized;
        private readonly string _scope;
        private readonly string _textHint;
        private readonly object[] _args;

        public LocalizedString(string localized)
        {
            _localized = localized;
        }

        public LocalizedString(string localized, string scope, string textHint, object[] args)
        {
            _localized = localized;
            _scope = scope;
            _textHint = textHint;
            _args = args;
        }

        public static LocalizedString TextOrDefault(string text, LocalizedString defaultValue)
        {
            if (string.IsNullOrEmpty(text))
                return defaultValue;
            return new LocalizedString(text);
        }

        public string Scope
        {
            get { return _scope; }
        }

        public string TextHint
        {
            get { return _textHint; }
        }

        public object[] Args
        {
            get { return _args; }
        }

        public string Text
        {
            get { return _localized; }
        }

        public override string ToString()
        {
            return _localized;
        }

        public string ToHtmlString()
        {
            return _localized;
        }
    }
}