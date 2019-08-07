import { Module } from 'vuex';
import { getters } from './getters';
import { actions } from './actions';
import { mutations } from './mutations';
import { PlayersState } from './types';
import { RootState } from '../types';

export const state: PlayersState = {
  players: [],
  loading: true,
};

const namespaced: boolean = true;

export const player: Module<PlayersState, RootState> = {
  namespaced,
  state,
  getters,
  actions,
  mutations,
};
