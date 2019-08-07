import { GetterTree } from 'vuex';
import { PlayersState } from './types';
import { RootState } from '../types';
import { Player } from '@/models/Player';

export const getters: GetterTree<PlayersState, RootState> = {
    getPlayers(state): Player[] {
        return state.players;
    },
    getLoading(state): boolean {
        return state.loading;
    },
};
