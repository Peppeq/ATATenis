<template>
	<div class="matches-container">
		<div v-if="!isEdit">
			<div class="rounds">
				<div class="round-header show-only-on-large-size round3">
					<h3 class="like-h3">Qualification</h3>
				</div>
				<div class="round-header show-only-on-large-size round3">
					<h3 class="like-h3">1st round</h3>
				</div>
				<div class="round-header show-only-on-large-size round3">
					<h3 class="like-h3">2nd round</h3>
				</div>
				<div class="round-header show-only-on-large-size round3">
					<h3 class="like-h3">Quarter-final</h3>
				</div>
				<div class="round-header show-only-on-large-size round3">
					<h3 class="like-h3">Semi-final</h3>
				</div>
				<div class="round-header show-only-on-large-size round3">
					<h3 class="like-h3">Final</h3>
				</div>
			</div>
			<div class="draw-qualification-container">
				<div class="qualification-32">
					<!-- <div class="grid-qualification-matches">
						<div class="qualification-match-3">
							<ul>
								<table>
									<tr>
										<th>Peter Sveter</th>
										<td>2</td>
										<td>3</td>
										<td>-</td>
									</tr>
									<tr>
										<th>Jano Slany</th>
										<td>6</td>
										<td>6</td>
										<td>-</td>
									</tr>
								</table>
							</ul>
						</div>
						<div class="qualification-match-4">
							<ul>
								<table>
									<tr>
										<th>Peter Sveter</th>
										<td>2</td>
										<td>3</td>
										<td>-</td>
									</tr>
									<tr>
										<th>Jano Slany</th>
										<td>6</td>
										<td>6</td>
										<td>-</td>
									</tr>
								</table>
							</ul>
						</div>
						<div class="qualification-match-6">
							<ul>
								<table>
									<tr>
										<th>Peter Sveter</th>
										<td>2</td>
										<td>3</td>
										<td>-</td>
									</tr>
									<tr>
										<th>Jano Slany</th>
										<td>6</td>
										<td>6</td>
										<td>-</td>
									</tr>
								</table>
							</ul>
						</div>
					</div> -->
					<div class="draw-32-qualification">
						<div class="draw-matches-16">
							<section class="matches qualification show-only-on-large-size round1">
								<ul v-visible="false" class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
							</section>
						</div>
						<div class="draw-matches-16">
							<section class="matches qualification show-only-on-large-size round1">
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
							</section>
						</div>
					</div>
				</div>
				<div class="draw-container">
					<div class="draw-32">
						<div class="draw-matches-16">
							<section class="matches show-only-on-large-size round1">
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
							</section>
							<section class="matches show-only-on-large-size round2">
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
							</section>
							<section class="matches show-only-on-large-size round3">
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
							</section>
							<section class="matches show-only-on-large-size round4">
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
							</section>
						</div>
						<div class="draw-matches-16">
							<section class="matches show-only-on-large-size round1">
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
							</section>
							<section class="matches show-only-on-large-size round2">
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
							</section>
							<section class="matches show-only-on-large-size round3">
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
							</section>
							<section class="matches show-only-on-large-size round4">
								<ul class="opponents">
									<li>
										<div class="match-container">
											<table>
												<tr>
													<th>Peter Sveter</th>
													<td>2</td>
													<td>3</td>
													<td>-</td>
												</tr>
												<tr>
													<th>Jano Slany</th>
													<td>6</td>
													<td>6</td>
													<td>-</td>
												</tr>
											</table>
										</div>
									</li>
								</ul>
							</section>
						</div>
					</div>
					<div class="draw-final">
						<section class="matches show-only-on-large-size round5">
							<ul class="opponents">
								<li>
									<div class="match-container">
										<table>
											<tr>
												<th>Peter Sveter</th>
												<td>2</td>
												<td>3</td>
												<td>-</td>
											</tr>
											<tr>
												<th>Jano Slany</th>
												<td>6</td>
												<td>6</td>
												<td>-</td>
											</tr>
										</table>
									</div>
								</li>
							</ul>
						</section>
					</div>
				</div>
			</div>
		</div>
		<div v-if="isEdit">
			abc
		</div>
	</div>
</template>

<script lang="ts">
import { BaseComponentClass } from "../../common/BaseComponentClass";
import Component from "vue-class-component";
import { Prop } from "vue-property-decorator";
import { PlayerDrawDTO } from "../../Api/TournamentEntryController";

@Component
export default class TournamentDraw extends BaseComponentClass {
	@Prop() readonly acceptedPlayers: PlayerDrawDTO[];

	isEdit = true;
	playerCount = 0;
	draw = 0;

	created(): void {
		if (this.acceptedPlayers != null) {
			this.playerCount = this.acceptedPlayers.length;
		}
	}
}
</script>

<style lang="scss" scoped>
@import "@/styles/views/tournament/tournament-draw.scss";
</style>
