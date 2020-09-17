using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FlagData
{
    /// <summary>
    /// This model object represents a single flag
    /// </summary>
    public class Flag : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _country;
        /// <summary>
        /// Name of the country that this flag belongs to
        /// </summary>
        public string Country
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                    // Can pass the property name as a string,
                    // -or- let the compiler do it because of the
                    // CallerMemberNameAttribute on the RaisePropertyChanged method.
                    RaisePropertyChanged();
                }
            }
        }

        private string _imageUrl;
        /// <summary>
        /// Image URL for the flag (from resources)
        /// </summary>
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                if (_imageUrl != value)
                {
                    _imageUrl = value;
                    // Can pass the property name as a string,
                    // -or- let the compiler do it because of the
                    // CallerMemberNameAttribute on the RaisePropertyChanged method.
                    RaisePropertyChanged();
                }
            }
        }

        private DateTime _dateAdopted;
        /// <summary>
        /// The date this flag was adopted
        /// </summary>
        public DateTime DateAdopted
        {
            get { return _dateAdopted; }
            set
            {
                if (_dateAdopted != value)
                {
                    _dateAdopted = value;
                    // Can pass the property name as a string,
                    // -or- let the compiler do it because of the
                    // CallerMemberNameAttribute on the RaisePropertyChanged method.
                    RaisePropertyChanged();
                }
            }
        }

        private bool _includesShield;
        /// <summary>
        /// Whether the flag includes an image/shield as part of the design
        /// </summary>
        public bool IncludesShield
        {
            get { return _includesShield; }
            set
            {
                if (_includesShield != value)
                {
                    _includesShield = value;
                    // Can pass the property name as a string,
                    // -or- let the compiler do it because of the
                    // CallerMemberNameAttribute on the RaisePropertyChanged method.
                    RaisePropertyChanged();
                }
            }
        }

        private string _description;
        /// <summary>
        /// Some trivia or commentary about the flag
        /// </summary>
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    // Can pass the property name as a string,
                    // -or- let the compiler do it because of the
                    // CallerMemberNameAttribute on the RaisePropertyChanged method.
                    RaisePropertyChanged();
                }
            }
        }

        private Uri _moreInformationUrl;
        /// <summary>
        /// A URL for more information
        /// </summary>
        public Uri MoreInformationUrl
        {
            get { return _moreInformationUrl; }
            set
            {
                if (_moreInformationUrl != value)
                {
                    _moreInformationUrl = value;
                    // Can pass the property name as a string,
                    // -or- let the compiler do it because of the
                    // CallerMemberNameAttribute on the RaisePropertyChanged method.
                    RaisePropertyChanged();
                }
            }
        }
    }
}
