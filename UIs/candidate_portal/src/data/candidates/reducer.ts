import {
  ICandidateState,
  LoadState,
  CandidateActionTypes,
  LOAD_DATA_IN_PROGRESS,
  LOAD_DATA_FAILED,
  LOAD_DATA_SUCCESS,
} from './types';

const initialState: ICandidateState = {
  loadState: LoadState.Never,
  candidateData: null,
};

const candidateReducer = (
  state = initialState,
  action: CandidateActionTypes,
): ICandidateState => {
  switch (action.type) {
    case LOAD_DATA_IN_PROGRESS: {
      const newState = { ...initialState, loadState: LoadState.Never };
      return newState;
    }
    case LOAD_DATA_FAILED: {
      const newState = { ...initialState, loadState: LoadState.Failed };
      return newState;
    }
    case LOAD_DATA_SUCCESS: {
      const newState = {
        candidateData: action.payload,
        loadState: LoadState.Success,
      };
      return newState;
    }
    default:
      return state;
  }
};

export default candidateReducer;
