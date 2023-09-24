<template>
  <section :class="getClassByRound(roundMatchProp.roundMatch.round)">
    <!-- <div v-for="(matchup) in matchups" :key="matchup.mIndex" class="winners"> -->
    <div v-for="(matchup, index) in matchups" :key="index" class="winners">
      <tournament-draw-matchup :matchupMatchesProp="matchup" :isFirstRound="isFirstRound"></tournament-draw-matchup>
      <div class="connector">
        <div class="merger"></div>
        <div class="line"></div>
      </div>
    </div>
  </section>
</template>

<script lang="ts">
import { BaseComponentClass } from '../../../common/BaseComponentClass'
import { Component, Prop, Watch } from 'vue-property-decorator';
import TournamentDrawMatchEntry from "./tournament-draw-match-entry.vue";
import TournamentDrawMatchup from "./tournament-draw-matchup.vue";
import { QualificationOrder, Round } from '../TournamentDraw.vue';
import { MatchDTO } from '@/Api/dtos/MatchDTO';
import { TournamentRound } from '@/Api/enums/TournamentRound';

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
  @Prop() readonly roundMatchProp: Round;
  // @Prop() readonly getQualificationMatchOrderProp: (match: MatchDTO) => QualificationOrder;
  // @Prop() readonly isQualificationRound: (roundMatch: RoundMatchDTO) => boolean;
  // @Prop() readonly getQualificationRound: () => RoundMatchDTO;

  @Watch("roundMatchProp")
  onRoundMatchPropChange(round: Round) {
    this.initMatchupsFromMatches(round.roundMatch.matches);
  }

  matchups: Matchup[] = [];
  isFirstRound = false;

  getClassByWinner(index: number): string {
    if (index == 1) {
      return "participant winner"
    } else {
      return "participant";
    }
  }

  initMatchupsFromMatches(matches: MatchDTO[]) {
    this.matchups = [];
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
      case TournamentRound.round2:
        roundClass = "round quarterfinals" // temporarily add new clases
        break;
      case TournamentRound.round3:
        roundClass = "round quarterfinals" // temporarily add new clases
        break;
      case TournamentRound.round4:
        roundClass = "round quarterfinals"
        break;
      case TournamentRound.round5:
        roundClass = "round semifinals"
        break;
      case TournamentRound.round6:
        roundClass = "round finals"
        break;
    }
    return roundClass;
  }

  created() {
    if (this.roundMatchProp?.roundMatch?.matches?.length > 0) {
      let matches = this.roundMatchProp.roundMatch.matches;
      // if (this.isQualificationRound && this.isQualificationRound(this.roundMatchProp)) {
      //   matches = this.getQualificationRound().Matches;
      // } else {
      //   matches = this.roundMatchProp.Matches;
      // }

      this.initMatchupsFromMatches(matches)
      this.isFirstRound = this.roundMatchProp.isFirstRound;
      console.log(this.matchups);
    }
  }
}
</script>

<style lang="scss" scoped>
@import "@/styles/views/tournament/tournament-draw.scss";
</style>
