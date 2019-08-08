import { GetterTree } from 'vuex';
import { PlayersState } from './types';
import { RootState } from '../types';
import { Player } from '@/models/Player';
import { PlayerShirtModel } from '@/models/PlayerShirtModel';

export const getters: GetterTree<PlayersState, RootState> = {
    players(state): Player[] {
        return state.players;
    },
    playerShirts(state): PlayerShirtModel[] {
        return state.playerShirts;
    },
};
