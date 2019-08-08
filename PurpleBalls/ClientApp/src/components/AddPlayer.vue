<template>
  <v-dialog v-model="dialog" persistent max-width="600px">
    <template v-slot:activator="{ on }">
      <v-btn color="primary" dark v-on="on" @click="resetPlayer()">
        <v-icon left dark>person_add</v-icon>
        Add Player
      </v-btn>
    </template>
    <v-card>
      <v-form
        ref="form"
        v-model="valid"
        lazy-validation
      >
      <v-card-title>
        <span class="headline">Add Player</span>
      </v-card-title>
      <v-card-text>
        <v-container grid-list-md>
          <v-layout wrap>
            <v-flex xs12 sm6 md6>
              <v-text-field label="First name*" v-model="player.firstName" :rules="formRules.firstName" required></v-text-field>
            </v-flex>
            <v-flex xs12 sm6 md6>
              <v-text-field label="Last name*" v-model="player.lastName" :rules="formRules.lastName" required></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field label="Email*" v-model="player.email" :rules="formRules.email" required></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field label="Phone number*" v-model="player.phoneNumber" :rules="formRules.telephone" required></v-text-field>
            </v-flex>
          </v-layout>
        </v-container>
        <small>*indicates required field</small>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
          color="blue darken-1"
          flat
          @click="dialog = false"
          :disabled="saving">Close</v-btn>

        <v-btn 
          color="blue darken-1"
          flat
          @click="savePlayer()"
          :loading="saving"
          :disabled="saving">Save</v-btn>
      </v-card-actions>
      </v-form>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import axios from 'axios';
import { State, Action, Getter } from 'vuex-class';
import { Component, Prop, Vue } from 'vue-property-decorator';
import { Player } from '../models/Player';
const namespace: string = 'player';

@Component
export default class AddPlayer extends Vue {
  private player: Player = {
    playerId: 0,
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    isDeleted: false,
  };

  private formRules: any = {
    firstName: [(v: any) => !!v || 'First Name is required'],
    lastName: [(v: any) => !!v || 'Last Name is required'],
    email: [
      (v: any) => !!v || 'E-mail is required',
      (v: any) => /.+@.+\..+/.test(v) || 'E-mail must be valid',
    ],
    telephone: [(v: any) => !!v || 'Telephone is required'],
  };

  @Action('addPlayer', { namespace })
  private addPlayer!: any;
  private valid: boolean = false;
  
  private saving: boolean = false;
  private dialog: boolean = false;

  private savePlayer() {
    this.saving = true;
    
    if (!(this.$refs.form as any).validate()) {
      this.saving = false;
      return;
    }

    this.addPlayer(this.player).finally(() => {
      this.saving = false;
      this.dialog = false;
    });
  }

  private resetPlayer() {
    this.player.playerId = 0;
    this.player.firstName = '';
    this.player.lastName = '';
    this.player.email = '';
    this.player.phoneNumber = '';
    this.player.isDeleted = false;
    (this.$refs.form as any).resetValidation();
  }
  
  private validate() {
    
  }
}
</script>
