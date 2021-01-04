import React, { ReactElement } from 'react';
import { connect, ConnectedProps } from 'react-redux';
import { ThunkDispatch } from 'redux-thunk';
import { loadCandidateDataThunk } from '../data/candidates/thunks';
import { CandidateActionTypes } from '../data/candidates/types';
import { IRootState } from '../data/types';

type Props = ConnectedProps<typeof connector>;

const mapStateToProps = (state: IRootState) => ({
  candidateState: state.candidateReducer,
});

const mapDispatchToProps = (
  dispatch: ThunkDispatch<IRootState, void, CandidateActionTypes>,
) => ({
  loadCandidateData: () => dispatch(loadCandidateDataThunk()),
});

const connector = connect(mapStateToProps, mapDispatchToProps);

const Dashboard = ({
  candidateState,
  loadCandidateData,
}: Props): ReactElement => (
  <>
    <div
      style={{
        borderWidth: 1,
        borderColor: 'black',
        border: 'solid',
        padding: 10,
        margin: 10,
      }}
    >
      <h1>Dashboard</h1>
      <p>{candidateState?.loadState || 'none'}</p>
      <p>{candidateState?.candidateData?.name || 'none'}</p>
      <button onClick={() => loadCandidateData()}>Thunk</button>
    </div>
  </>
);

export default connector(Dashboard);
