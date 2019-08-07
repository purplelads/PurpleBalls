import { Player } from '@/models/Player';

export interface PlayersState {
    players: Player[];
    loading: boolean;
}
