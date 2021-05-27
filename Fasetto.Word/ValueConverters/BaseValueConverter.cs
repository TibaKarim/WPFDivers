using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace Fasetto.Word
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T:class ,new()
    {
        #region Private Members
        private static T mConverter = null;
        #endregion
        #region Markup Extension Methodes
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //if (mConverter == null)
            //    mConverter = new T();
            //return mConverter;
            return mConverter ??= new T();
        }
        #endregion
        #region Value Converter Methode
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);


        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
       
        #endregion
    }
}
