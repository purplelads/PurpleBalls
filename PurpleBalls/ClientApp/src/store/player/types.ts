import { Player } from '@/models/Player';
import { PlayerShirtModel } from '@/models/PlayerShirtModel';

export interface PlayersState {
    players: Player[];
    playerShirts: PlayerShirtModel[];
}
