import axios from 'axios';
import { MutationTree } from 'vuex';
import { PlayersState } from './types';
import { Player } from '@/models/Player';

export const mutations: MutationTree<PlayersState> = {
  getPlayers(state) {
    state.loading = true;

    axios
        .get<Player[]>('api/players')
        .then((response) => {
            state.players = response.data;
        })
        .catch((e) => {
            state.players = [];
        })
        .finally(() => {
            state.loading = false;
        });
  },
  addPlayer(state, player: Player) {
    axios
        .post<Player>('api/players', player)
        .then((response) => {
            state.players.push(response.data);
        });
  },
};
