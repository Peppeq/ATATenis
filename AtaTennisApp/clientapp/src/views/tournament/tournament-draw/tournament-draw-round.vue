<template>
  <section :class="getClassByRound(roundMatchProp.Round)">
    <div v-for="(matchup) in matchups" :key="matchup.mIndex" class="winners">
      <tournament-draw-matchup :matchupMatchesProp="matchup.matches"></tournament-draw-matchup>
      <!-- <div class="matchups">
        <div v-for="(match) in matchup.matches" :key="match.mIndex" class="matchup">
          <div class="participants">
            <div v-for="(matchEntry, entryIndex) in match.MatchEntries" :key="matchEntry.Id" :class="getClassByWinner(entryIndex)">
              <tournament-draw-match :tournamentMatch="match" :tournamentMatchIndex="matchIndex"></tournament-draw-match>
            </div>
          </div>
        </div>
      </div> -->
      <div class="connector">
        <div class="merger"></div>
        <div class="line"></div>
      </div>
    </div>
  </section>
</template>

<script lang="ts">
import { BaseComponentClass } from '../../../common/BaseComponentClass'
import { Component, Prop } from 'vue-property-decorator';
import { MatchDTO } from '@/Api/MatchController';
import TournamentDrawMatchEntry from "./tournament-draw-match-entry.vue";
import TournamentDrawMatchup from "./tournament-draw-matchup.vue";
import {
  DrawDTO,
  TournamentRound,
  RoundMatchDTO
} from '../../../Api/TournamentController';

interface Matchup {
  mIndex: number,
  matches: MatchDTO[]
}

@Component({
  components: {
    TournamentDrawMatchup
  }
})
export default class TournamentDrawRound extends BaseComponentClass {
  @Prop() readonly roundMatchProp: RoundMatchDTO;
  draw: DrawDTO = null;
  matchups: Matchup[] = [];

  getClassByWinner(index: number): string {
    if (index == 1) {
      return "participant winner"
    } else {
      return "participant";
    }
  }

  initMatchupsFromMatches(matches: MatchDTO[]) {
    matches.forEach((value, index) => {
      if ((index + 1) % 2 == 1) {
        let matchupIndex = +(index / 2).toFixed(0);
        this.matchups.push({ mIndex: matchupIndex, matches: [] });
        this.matchups[matchupIndex].matches.push(value);
      } else {
        let matchupIndex = +(index / 2).toFixed(0) - 1;
        this.matchups[matchupIndex].matches.push(value);
      }
    });
  }

  getClassByRound(round: TournamentRound): string {
    let roundClass = "";
    switch (round) {
      case TournamentRound.round3:
        roundClass = "round quarterfinals" // temporarily add new clases
        break;
      case TournamentRound.round4:
        roundClass = "round quarterfinals"
        console.log(round)
        break;
      case TournamentRound.round5:
        roundClass = "round semifinals"
        console.log(roundClass)
        break;
      case TournamentRound.round6:
        roundClass = "round finals"
        console.log(roundClass)
        break;
    }
    return roundClass;
  }

  // created() {
  //   this.draw = this.drawProp;
  // }

  created() {
    if (this.roundMatchProp && this.roundMatchProp.Matches && this.roundMatchProp.Matches.length > 0) {
      this.initMatchupsFromMatches(this.roundMatchProp.Matches)
      console.log(this.matchups);
    }
  }
}
</script>

<style lang="scss" scoped>
@import "@/styles/views/tournament/tournament-draw.scss";
</style>
