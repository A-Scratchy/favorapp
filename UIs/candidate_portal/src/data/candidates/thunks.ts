import { Dispatch } from 'react';
import { loadCandidateDataSuccessCreator } from './actions';
import { CandidateActionTypes } from './types';

// eslint-disable-next-line import/prefer-default-export
export const loadCandidateDataThunk = () => (
  dispatch: Dispatch<CandidateActionTypes>,
) => {
  dispatch(
    loadCandidateDataSuccessCreator({
      // TODO call api async
      name: 'candidate1',
    }),
  );
};

const candidateEndpoint = 'http://localhost:5001/Candidate';
