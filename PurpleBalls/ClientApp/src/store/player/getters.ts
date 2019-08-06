import { GetterTree } from 'vuex';
import { PlayerState } from './types';
import { RootState } from '../types';
import { Player } from '@/models/Player';

export const getters: GetterTree<PlayerState, RootState> = {
    getPlayer(state): Player {
        return state.player;
    },
};
