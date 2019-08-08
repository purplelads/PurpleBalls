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
  deletePlayer(state, id: number) {
    for (let i = 0; i < state.players.length; i++) {
      if (state.players[i].playerId === id) {
        state.players.splice(i, 1);
        return;
      }
    }
  },
};
