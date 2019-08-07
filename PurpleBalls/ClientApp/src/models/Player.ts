export class Player {
    constructor(
        public playerId: number,
        public firstName: string,
        public lastName: string,
        public email: string,
        public phoneNumber: string,
        public isDeleted: boolean,
        public shirtNumber: number,
        public shirtName: string,
    ) { }
  }
