import { applyMiddleware, combineReducers, createStore } from 'redux';
import thunk from 'redux-thunk';
import candidateReducer from './candidates/reducer';

const rootReducer = combineReducers({ candidateReducer });

const store = createStore(rootReducer, applyMiddleware(thunk));
export default store;
