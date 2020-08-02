<template>
  <d-input-group>
    <!-- <div v-if="match.Round == startingRoundProp">
        <div v-for="entry in match.MatchEntries" :key="entry.Id">
          {{entry.Id}}

        </div>
      </div> -->
    <d-input-group-addon prepend>
      <d-btn outline theme="success" @click="addQualifier">Qualifier</d-btn>
    </d-input-group-addon>
    <input type="text" :value="match.PlayerId" aria-label="Text input with checkbox" class="form-control" />
    <d-input-group-text slot="append">
      <input type="checkbox" aria-label="Checkbox for following text input" />
    </d-input-group-text>
  </d-input-group>
</template>

<script lang="ts">
import { BaseComponentClass } from '../../../common/BaseComponentClass'
import { Component, Prop } from 'vue-property-decorator'
import { MatchDTO } from '@/Api/MatchController';
import { MatchEntryDTO } from '../../../Api/TournamentController';

@Component
export default class TournamentDrawMatchEntry extends BaseComponentClass {
  @Prop() readonly tournamentMatchEntry: MatchEntryDTO;
  // @Prop() readonly tournamentMatchIndex: number;
  matchEntry: MatchEntryDTO = null;
  // isEven: boolean = false;

  checkIfEven(index: number): boolean {
    return index % 2 > 0 ? true : false;
  }

  addQualifier() {
    this.$eventHub.$emit('addQualificationMatch', this.matchEntry.Id);
  }

  created() {
    if (this.tournamentMatchEntry != null) {
      this.matchEntry = this.tournamentMatchEntry;
      // this.isEven = this.checkIfEven(this.tournamentMatchIndex);
    }
  }
}
</script>

<style>
</style>
