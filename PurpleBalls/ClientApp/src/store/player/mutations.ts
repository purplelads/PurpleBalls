import { MutationTree } from 'vuex';
import { PlayersState } from './types';
import { Player } from '@/models/Player';

export const mutations: MutationTree<PlayersState> = {
  setPlayers(state, players) {
    state.players = players;
  },
  addPlayer(state, player: Player) {
    state.players.push(player);
  },
};
