<template>
  <d-input-group>
    <d-input-group-addon v-if="canAddQualifier()" prepend>
      <d-btn outline theme="success" @click="addQualifier">Qualifier</d-btn>
    </d-input-group-addon>
    <input type="text" :value="matchEntry.playerId" aria-label="Text input with checkbox" class="form-control" />
    <d-input-group-text slot="append">
      <input type="checkbox" aria-label="Checkbox for following text input" />
    </d-input-group-text>
  </d-input-group>
</template>

<script lang="ts">
import { BaseComponentClass } from '../../../common/BaseComponentClass'
import { Component, Prop, Watch } from 'vue-property-decorator'
import { MatchEntryDTO } from '@/Api/dtos/MatchEntryDTO';

@Component
export default class TournamentDrawMatchEntry extends BaseComponentClass {
  @Prop() readonly tournamentMatchEntry: MatchEntryDTO;
  @Prop() readonly isFirstRound: boolean;
  matchEntry: MatchEntryDTO = null;

  @Watch("tournamentMatchEntry")
  onTournamentMatchEntryChange(matchEntry: MatchEntryDTO) {
    this.matchEntry = matchEntry;
  }

  checkIfEven(index: number): boolean {
    return index % 2 > 0 ? true : false;
  }

  addQualifier() {
    this.$eventHub.$emit('addQualificationMatch', this.matchEntry.id);
  }

  canAddQualifier(): boolean {
    return this.isFirstRound && this.matchEntry.parentMatchId == null;
  }

  created() {
    if (this.tournamentMatchEntry != null) {
      this.matchEntry = this.tournamentMatchEntry;
    }
  }
}
</script>

<style>
</style>
