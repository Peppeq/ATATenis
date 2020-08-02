<template>
  <div class="matchups">
    <div v-for="(match, matchIndex) in matchupMatchesProp" :key="match.mIndex" class="matchup">
      <div class="participants">
        <div v-for="(matchEntry, entryIndex) in match.MatchEntries" :key="matchEntry.Id" :class="getClassByWinner(entryIndex)">
          <tournament-draw-match-entry :tournamentMatchEntry="matchEntry" :tournamentMatchIndex="matchIndex"></tournament-draw-match-entry>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { BaseComponentClass } from '../../../common/BaseComponentClass'
import { Component, Prop, Watch } from 'vue-property-decorator';
import { MatchDTO } from '@/Api/MatchController';
import TournamentDrawMatchEntry from "./tournament-draw-match-entry.vue";
import { DrawDTO, TournamentRound } from '../../../Api/TournamentController';

interface Matchup {
  index: number,
  matches: MatchDTO[]
}


// Role of this component is separate matches from round to matchups
@Component({
  components: {
    TournamentDrawMatchEntry
  }
})
export default class TournamentDrawMatchup extends BaseComponentClass {
  @Prop() readonly matchupMatchesProp: MatchDTO[];

  getClassByWinner(index: number): string {
    if (index == 1) {
      return "participant winner"
    } else {
      return "participant";
    }
  }

  // @Watch("matchesProp")
  // ontournamentMatchDTOChange(matchesProp: MatchDTO[]): void {
  //   this.initMatchupsFromMatches(matchesProp);
  // }

  // initMatchupsFromMatches(matches: MatchDTO[]) {
  //   matches.forEach((value, index) => {
  //     if ((index + 1) % 2 == 1) {
  //       let matchupIndex = +(index / 2).toFixed(0);
  //       this.matchups.push({ index: matchupIndex, matches: [] });
  //       this.matchups[matchupIndex].matches.push(value);
  //     } else {
  //       let matchupIndex = +(index / 2).toFixed(0) - 1;
  //       this.matchups[matchupIndex].matches.push(value);
  //     }
  //   });
  // }

  created() {
    // if (this.matchesProp && this.matchesProp.length > 0) {
    //   this.initMatchupsFromMatches(this.matchesProp)
    //   console.log(this.matchups);
    // }
  }
}
</script>

<style lang="scss" scoped>
@import "@/styles/views/tournament/tournament-draw.scss";
</style>
