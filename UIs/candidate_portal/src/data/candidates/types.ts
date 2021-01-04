export interface ICandidateState {
  loadState: LoadState;
  candidateData: ICandidateData | null;
}

export enum LoadState {
  Never = 'never',
  Loading = 'loading',
  Failed = 'failed',
  Success = 'success',
}

export interface ICandidateData {
  name: string;
}

export const LOAD_DATA_IN_PROGRESS = 'LOAD_DATA_IN_PROGRESS';
export interface LoadCandidateDataInProgress {
  type: typeof LOAD_DATA_IN_PROGRESS;
}

export const LOAD_DATA_FAILED = 'LOAD_DATA_FAILED';
export interface LoadCandidateDataFailed {
  type: typeof LOAD_DATA_FAILED;
}

export const LOAD_DATA_SUCCESS = 'LOAD_DATA_SUCCESS';
export interface LoadCandidateDataSuccess {
  type: typeof LOAD_DATA_SUCCESS;
  payload: ICandidateData;
}

export type CandidateActionTypes =
  | LoadCandidateDataInProgress
  | LoadCandidateDataFailed
  | LoadCandidateDataSuccess;
