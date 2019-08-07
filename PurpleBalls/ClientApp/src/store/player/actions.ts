import { ActionTree } from 'vuex';
import { PlayersState } from './types';
import { RootState } from '../types';
import { Player } from '@/models/Player';

export const actions: ActionTree<PlayersState, RootState> = {
  getPlayers({ commit }): any {
    commit('getPlayers');
  },
  addPlayer({ commit }, player: Player): any {
      commit('addPlayer', player);
  },
};
