﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherAggregator.Repository {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ApisUrlsNames {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ApisUrlsNames() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WeatherAggregator.Repository.ApisUrlsNames", typeof(ApisUrlsNames).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://api.wunderground.com/api/d560e8d2602ee998/conditions/q/{0}.json.
        /// </summary>
        public static string BaseCitiesUrl {
            get {
                return ResourceManager.GetString("BaseCitiesUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to https://api.theprintful.com/countries.
        /// </summary>
        public static string BaseCountriesUrl {
            get {
                return ResourceManager.GetString("BaseCountriesUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to https://pixabay.com/api/?key=3018114-ef10ea70a2ba5da78d32b52be&amp;q={0}&amp;image_type=photo.
        /// </summary>
        public static string BaseImageUrl {
            get {
                return ResourceManager.GetString("BaseImageUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://api.wunderground.com/api/d560e8d2602ee998/conditions/q/{0}/{1}.json.
        /// </summary>
        public static string BaseStateCitiesUrl {
            get {
                return ResourceManager.GetString("BaseStateCitiesUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to https://lh3.ggpht.com/ApTda64T1v2cef_XzU6NHvt0nKPFTTJ1ZuBo6iuqovXTvqEGVxXxAnBH-XOz7ijNRYMONA=w{0}.
        /// </summary>
        public static string DefaultImageSource {
            get {
                return ResourceManager.GetString("DefaultImageSource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://api.openweathermap.org/data/2.5/weather?q={0},{1},{2}&amp;appid=5c534ef4999710bd65efedf91d6295e4&amp;units=metric.
        /// </summary>
        public static string OpenWeatherMapCountryStateURL {
            get {
                return ResourceManager.GetString("OpenWeatherMapCountryStateURL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://api.openweathermap.org/data/2.5/weather?q={0},{1}&amp;appid=5c534ef4999710bd65efedf91d6295e4&amp;units=metric.
        /// </summary>
        public static string OpenWeatherMapCountryURL {
            get {
                return ResourceManager.GetString("OpenWeatherMapCountryURL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://api.wunderground.com/api/d560e8d2602ee998/conditions/q/{0}/{1}/{2}.json.
        /// </summary>
        public static string WundergroundCountryStateURL {
            get {
                return ResourceManager.GetString("WundergroundCountryStateURL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://api.wunderground.com/api/d560e8d2602ee998/conditions/q/{0}/{1}.json.
        /// </summary>
        public static string WundergroundCountryURL {
            get {
                return ResourceManager.GetString("WundergroundCountryURL", resourceCulture);
            }
        }
    }
}