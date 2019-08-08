import { GetterTree } from 'vuex';
import { PlayersState } from './types';
import { RootState } from '../types';
import { Player } from '@/models/Player';

export const getters: GetterTree<PlayersState, RootState> = {
    players(state): Player[] {
        return state.players;
    },
};
