using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MoodSwings.Shared.ViewModels.PlaylistViewModels;
using MoodSwings.Shared.Models.SpotifyModels;
using MoodSwings.Services;
using MoodSwings.Shared.Models.DTO;

namespace MoodSwings.Shared.Store
{
    public class AppState
    {
        #region Private Members
        /// <summary>
        /// 
        /// </summary>
        private SpotifyService _spotifyService;
        private AuthenticationService _authService;

        private TempoViewModel _currentTempoVM = new TempoViewModel
        {
            IncludeHalftime = false,
            Tempo = 0,
            Precision = 0
        };

        private int _currentStep = 1;

        private TracksDefinitionViewModel _currentTrackDefinition = new TracksDefinitionViewModel
        {
            Id = "",
            TempoModel = new TempoViewModel
            {
                IncludeHalftime = false,
                Tempo = 0,
                Precision = 0
            }
        };

        private string _selectedPlaylistId;

        private List<PlaylistTrack> _collectedTracks = new List<PlaylistTrack>();

        public IReadOnlyList<PlaylistTrack> CollectedTracks => _collectedTracks;

        private List<PlaylistTrack> assembledTracks = new List<PlaylistTrack>();

        #endregion

        #region Public Accessors
        public int CurrentStep => _currentStep;

        public IList<Playlist> Playlists { get; set; }

        public TracksDefinitionViewModel CurrentTrackDefinition => _currentTrackDefinition;

        public string SelectedPlaylistId => _selectedPlaylistId;

        public TempoViewModel CurrentTempoViewModel
        {
            get
            {
                return _currentTempoVM;
            }
            set
            {
                UpdateTempoModel(value);
            }

        }


        public bool ModelIsValid => _currentTrackDefinition.Id != "" && _currentTrackDefinition.TempoModel != null;

        #endregion


        #region Public Actions/Events
        public event Action OnCurrentTempoModelUpdated;
        public event Action OnCurrentTrackDefinitionUpdated;

        #endregion

        #region Private Methods
        private void TempoVMStateChanged() => OnCurrentTempoModelUpdated?.Invoke();
        private void TracksDefinitionVMStateChanged() => OnCurrentTrackDefinitionUpdated?.Invoke();
        #endregion

        #region Public Methods
        public void UpdateTempoModel(TempoViewModel vm)
        {
            _currentTempoVM = vm;
            TempoVMStateChanged();
        }
        public void UpdateDefinition(TracksDefinitionViewModel tdvm, TempoViewModel tvm)
        {
            _currentTrackDefinition = tdvm;
            _currentTrackDefinition.TempoModel = tvm;
            _selectedPlaylistId = tdvm.Id;
            System.Console.WriteLine(_currentTrackDefinition.TempoModel.Tempo);
            System.Console.WriteLine(_currentTrackDefinition.TempoModel.Precision);
            TracksDefinitionVMStateChanged();

        }

        public async Task MoveForward()
        {
            try
            {
                switch (_currentStep)
                {
                    case 1:

                        var request = new TempoDefinitionRequestDTO
                        {
                            access_token = _authService.Token.AccessToken,
                            options = new OptionsDTO { limit = 50, offset = 0 },
                            playlist = _currentTrackDefinition.Id,
                            criteria = new TempoCriteriaDTO
                            {
                                type = "tempo",
                                parameters = new TempoDTO
                                {
                                    value = _currentTrackDefinition.TempoModel.Tempo,
                                    precision = _currentTrackDefinition.TempoModel.Precision,
                                    halfTempoAllowed = _currentTrackDefinition.TempoModel.IncludeHalftime
                                }

                            },
                        };
                        break;
                }
            }
            catch (System.Exception)
            {

                throw;
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task GetUserPlaylists()
        {
            try
            {
                if (_authService.IsAuthenticated)
                {
                    var request = new RequestDTO
                    {
                        access_token = _authService.Token.AccessToken,
                        options = new OptionsDTO
                        {
                            limit = 20,
                            offset = 0
                        },
                    };
                    var pls = await _spotifyService.GetUserPlaylists(request);
                    Playlists = pls.Items;
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spotifyService"></param>
        /// <param name="authService"></param>
        public AppState(SpotifyService spotifyService, AuthenticationService authService)
        {
            _spotifyService = spotifyService;
            _authService = authService;
        }
    }
}