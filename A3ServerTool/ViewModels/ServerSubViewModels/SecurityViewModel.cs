﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using A3ServerTool.Enums;
using A3ServerTool.Models;
using GalaSoft.MvvmLight;

namespace A3ServerTool.ViewModels.ServerSubViewModels
{
    /// <summary>
    /// Provides VM for handling server security properties.
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    /// <seealso cref="System.ComponentModel.IDataErrorInfo" />
    public class SecurityViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly ServerViewModel _parentViewModel;

        public Profile CurrentProfile => _parentViewModel.CurrentProfile;

        /// <summary>
        /// Gets or sets password required to get admin rights on server. 
        /// </summary>
        public string AdminPassword
        {
            get => CurrentProfile?.ServerConfig.AdminPassword;
            set
            {
                if (Equals(value, CurrentProfile.ServerConfig.AdminPassword)) return;
                CurrentProfile.ServerConfig.AdminPassword = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the admin IDs.
        /// </summary>
        public string AdminIds
        {
            get
            {
                var ids = CurrentProfile?.ServerConfig.AdminUids;
                if (ids != null)
                {
                    return string.Join(",", ids);
                }
                return null;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    CurrentProfile.ServerConfig.AdminUids = null;
                }
                else
                {
                    var valueAsArray = value?.Split(',');
                    if (Equals(valueAsArray, CurrentProfile?.ServerConfig.AdminUids)) return;
                    CurrentProfile.ServerConfig.AdminUids = valueAsArray.ToList();
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the kick duplicate uids.
        /// </summary>
        public int? KickDuplicateUids
        {
            get => CurrentProfile?.ServerConfig.KickDuplicateIds;
            set
            {
                if (Equals(value, CurrentProfile.ServerConfig.KickDuplicateIds)) return;
                CurrentProfile.ServerConfig.KickDuplicateIds = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets password required by alternate syntax of serverCommand server-side scripting. . 
        /// </summary>
        public string ServerCommandPassword
        {
            get => CurrentProfile?.ServerConfig.ServerCommandPassword;
            set
            {
                if (Equals(value, CurrentProfile.ServerConfig.ServerCommandPassword)) return;
                CurrentProfile.ServerConfig.ServerCommandPassword = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets password required by alternate syntax of serverCommand server-side scripting. 
        /// </summary>
        public FilePatching FilePatching
        {
            get
            {
                return (FilePatching) CurrentProfile.ServerConfig.FilePatchingMode;
            }
            set
            {
                if (Equals((int)value, CurrentProfile.ServerConfig.FilePatchingMode)) return;
                CurrentProfile.ServerConfig.FilePatchingMode = (int) value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the welcome messages.
        /// </summary>
        public string FilePatchingExceptions
        {
            get
            {
                var messages = CurrentProfile?.ServerConfig.FilePatchingExceptions;
                if (messages != null)
                {
                    return string.Join(",", messages);
                }
                return null;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    CurrentProfile.ServerConfig.FilePatchingExceptions = null;
                }
                else
                {
                    var valueAsArray = value?.Split(',');
                    if (Equals(valueAsArray, CurrentProfile?.ServerConfig.FilePatchingExceptions)) return;
                    CurrentProfile.ServerConfig.FilePatchingExceptions = valueAsArray.ToList();
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets action when second user with same ID is detected.
        /// </summary>
        public string DoubleIdScript
        {
            get => CurrentProfile?.ServerConfig.OnDoubleIdCommand;
            set
            {
                if (Equals(value, CurrentProfile.ServerConfig.OnDoubleIdCommand)) return;
                CurrentProfile.ServerConfig.OnDoubleIdCommand = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets action when user connected to the server.
        /// </summary>
        public string UserConnectedScript
        {
            get => CurrentProfile?.ServerConfig.OnUserConnectedCommand;
            set
            {
                if (Equals(value, CurrentProfile.ServerConfig.OnUserConnectedCommand)) return;
                CurrentProfile.ServerConfig.OnUserConnectedCommand = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the user disconnected script.
        /// </summary>
        public string UserDisconnectedScript
        {
            get => CurrentProfile?.ServerConfig.OnUserDisconnectedCommand;
            set
            {
                if (Equals(value, CurrentProfile.ServerConfig.OnUserDisconnectedCommand)) return;
                CurrentProfile.ServerConfig.OnUserDisconnectedCommand = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the hacked data script.
        /// </summary>
        public string HackedDataScript
        {
            get => CurrentProfile?.ServerConfig.OnHackedDataCommand;
            set
            {
                if (Equals(value, CurrentProfile.ServerConfig.OnHackedDataCommand)) return;
                CurrentProfile.ServerConfig.OnHackedDataCommand = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the different data script.
        /// </summary>
        public string DifferentDataScript
        {
            get => CurrentProfile?.ServerConfig.OnDifferentDataCommand;
            set
            {
                if (Equals(value, CurrentProfile.ServerConfig.OnDifferentDataCommand)) return;
                CurrentProfile.ServerConfig.OnDifferentDataCommand = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the unsigned data script.
        /// </summary>
        public string UnsignedDataScript
        {
            get => CurrentProfile?.ServerConfig.OnUnsignedDataCommand;
            set
            {
                if (Equals(value, CurrentProfile.ServerConfig.OnUnsignedDataCommand)) return;
                CurrentProfile.ServerConfig.OnUnsignedDataCommand = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the user kicked script.
        /// </summary>
        public string UserKickedScript
        {
            get => CurrentProfile?.ServerConfig.OnUserKickedCommand;
            set
            {
                if (Equals(value, CurrentProfile.ServerConfig.OnUserKickedCommand)) return;
                CurrentProfile.ServerConfig.OnUserKickedCommand = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets password required by alternate syntax of serverCommand server-side scripting.
        /// </summary>
        public SignatureVerificationType SignatureVerificationType
        {
            get
            {
                return (SignatureVerificationType) CurrentProfile.ServerConfig.SignatureVerificationMode;
            }
            set
            {
                if (Equals((int)value, CurrentProfile.ServerConfig.SignatureVerificationMode)) return;
                CurrentProfile.ServerConfig.SignatureVerificationMode = (int)value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has Battle Eye anticheat engine.
        /// </summary>
        public bool HasBattleEye
        {
            get => CurrentProfile.ServerConfig.HasBattleEye;
            set
            {
                if (Equals(value, CurrentProfile.ServerConfig.HasBattleEye)) return;
                CurrentProfile.ServerConfig.HasBattleEye = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets required build of the game to connect to the server.
        /// </summary>
        public string RequiredBuild
        {
            get => CurrentProfile?.ServerConfig.RequiredBuild;
            set
            {
                if (Equals(value, CurrentProfile.ServerConfig.RequiredBuild)) return;
                CurrentProfile.ServerConfig.RequiredBuild = value;
                RaisePropertyChanged();
            }
        }

        public SecurityViewModel(ServerViewModel viewModel)
        {
            _parentViewModel = viewModel;
        }

        public void IsAllowedInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #region IDataErrorInfo

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(AdminIds) when !string.IsNullOrWhiteSpace(AdminIds) && Regex.Matches(AdminIds, @"[a-zA-Z]").Count > 0:
                        return "Admin identifiers can be only numbers.";
                    default:
                        return null;
                }
            }
        }

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        #endregion
    }
}