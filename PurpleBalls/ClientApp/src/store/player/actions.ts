import axios from 'axios';
import { ActionTree } from 'vuex';
import { PlayersState } from './types';
import { RootState } from '../types';
import { Player } from '@/models/Player';
import { PlayerShirtModel } from '@/models/PlayerShirtModel';

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
  async deletePlayer({ commit }, id: number): Promise<void> {
    return axios
        .delete('api/players/' + id)
        .then((response) => {
            commit('deletePlayer', id);
        });
  },
  async getPlayerShirts({ commit }): Promise<void> {
    return axios
      .get<PlayerShirtModel[]>('api/players/shirts')
      .then((response) => {
        commit('setPlayerShirts', response.data);
      });
  },
  async savePlayerShirt({ commit }, playerShirt: PlayerShirtModel): Promise<void> {
    return axios
      .post<PlayerShirtModel>('api/players/saveShirt', playerShirt)
      .then((response) => {
        commit('savePlayerShirt', response.data);
      });
  },
};
