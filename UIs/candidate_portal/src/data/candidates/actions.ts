import {
  CandidateActionTypes,
  LOAD_DATA_IN_PROGRESS,
  LOAD_DATA_FAILED,
  ICandidateData,
  LOAD_DATA_SUCCESS,
} from './types';

export const loadCadidateDataInProgressCreator = (): CandidateActionTypes => ({
  type: LOAD_DATA_IN_PROGRESS,
});

export const loadCandidateDataFailedCreator = (): CandidateActionTypes => ({
  type: LOAD_DATA_FAILED,
});

export const loadCandidateDataSuccessCreator = (
  candidateData: ICandidateData,
): CandidateActionTypes => ({
  type: LOAD_DATA_SUCCESS,
  payload: candidateData,
});
