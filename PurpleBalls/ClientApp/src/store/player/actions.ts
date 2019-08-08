import axios from 'axios';
import { ActionTree } from 'vuex';
import { PlayersState } from './types';
import { RootState } from '../types';
import { Player } from '@/models/Player';

export const actions: ActionTree<PlayersState, RootState> = {
  async getPlayers({ commit }): Promise<void> {
    return axios
        .get<Player[]>('api/players')
        .then((response) => {
            commit('setPlayers', response.data);
        });
  },
  async addPlayer({ commit }, player: Player): Promise<void> {
    return axios
        .post<Player>('api/players', player)
        .then((response) => {
            commit('addPlayer', response.data);
        });
  },
};
