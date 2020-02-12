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
      <!-- Favourite Surface -->
      <div class="select-draw-size">
        <label for="drawSize">{{ "Draw Size" }}</label>
        <d-form-select id="drawSize" v-model="draw" :options="tournamentHelper.GetTournamentDrawSizes()" :value="draw" />
      </div>
      <div class="draw-matches-16">
        <section class="matches show-only-on-large-size round1">
        </section>
        <section class="matches show-only-on-large-size round2">
          <ul class="opponents">
            <li>
              <div v-for="(match, index) in matches" :key="match.Id" class="match-container">
                <div v-if="match.Round == startingRoundProp">
                  <div v-for="entry in match.MatchEntries" :key="entry.Id">
                    <table>
                      <tr>
                        {{ "match " + index + match.Round}}
                        <d-input-group :class="{ 'match-margin': isEven(index) }">
                          <d-input-group-addon prepend>
                            <d-btn outline theme="success" @click="addQualifier">Qualifier</d-btn>
                          </d-input-group-addon>
                          <input type="text" :value="entry.PlayerId" aria-label="Text input with checkbox" class="form-control" />
                          <d-input-group-text slot="append">
                            <input type="checkbox" aria-label="Checkbox for following text input" />
                          </d-input-group-text>
                        </d-input-group>
                      </tr>
                    </table>
                  </div>
                </div>
              </div>
            </li>
          </ul>
        </section>
      </div>
      <d-btn @click="createDraw">{{ matches != null && matches.length > 0 ? "Update" : "Create" }}</d-btn>
      <d-btn style="margin-left: 0.5%" v-if="matches != null && matches.length > 0" @click="deleteDraw">Delete</d-btn>
    </div>
  </div>
</template>

<script lang="ts">
import { BaseComponentClass } from "../../common/BaseComponentClass";
import Component from "vue-class-component";
import { Prop, Watch } from "vue-property-decorator";
import { PlayerDrawDTO } from "../../Api/TournamentEntryController";
import MatchClient, {
  MatchDTO,
  MatchesArgs,
  DrawSize,
  CreateOrUpdateMatchesArgs
} from "../../Api/MatchController";
import { TournamentHelper } from "./tournamentHelper";
import { NotificationUtils } from "../../common/notification";

@Component
export default class TournamentDraw extends BaseComponentClass {
  @Prop() readonly acceptedPlayersProp: PlayerDrawDTO[];
  @Prop() readonly tournamentMatches: MatchDTO[];
  @Prop() readonly tournamentId: number;
  @Prop() readonly startingRoundProp: number;
  @Prop() readonly isEditablePage: boolean;

  acceptedPlayers: PlayerDrawDTO[] = [];
  tournamentHelper = TournamentHelper;
  matchClient: MatchClient = new MatchClient();
  matches: MatchDTO[] = null;
  // startingRound: number;

  isEdit = false;
  playerCount = 0;
  draw: DrawSize = DrawSize.draw32;
  isQualification = false;

  // toto v podstate nepotrebujem
  // @Watch("tournamentMatches")
  // onTournamentMatchesPropChange(tournamentMatches: MatchDTO[]): void {
  //   this.matches = tournamentMatches;
  // }

  assignedPlayers: PlayerDrawDTO[] = [
    { TournamentEntryId: 1, PlayerId: 1, Name: "A", Surname: "A" },
    { TournamentEntryId: 2, PlayerId: 2, Name: "b", Surname: "b" },
    { TournamentEntryId: 3, PlayerId: 3, Name: "c", Surname: "c" },
    { TournamentEntryId: 4, PlayerId: 4, Name: "d", Surname: "d" },
    { TournamentEntryId: 5, PlayerId: 5, Name: "e", Surname: "e" },
    { TournamentEntryId: 6, PlayerId: 6, Name: "f", Surname: "f" },
    { TournamentEntryId: 7, PlayerId: 7, Name: "g", Surname: "g" },
    { TournamentEntryId: 8, PlayerId: 8, Name: "h", Surname: "h" },
    { TournamentEntryId: 9, PlayerId: 9, Name: "i", Surname: "i" },
    { TournamentEntryId: 10, PlayerId: 10, Name: "j", Surname: "j" },
    { TournamentEntryId: 11, PlayerId: 11, Name: "k", Surname: "k" },
    { TournamentEntryId: 12, PlayerId: 12, Name: "l", Surname: "l" },
    { TournamentEntryId: 13, PlayerId: 13, Name: "m", Surname: "m" },
    { TournamentEntryId: 14, PlayerId: 14, Name: "n", Surname: "n" },
    { TournamentEntryId: 15, PlayerId: 15, Name: "o", Surname: "o" },
    { TournamentEntryId: 16, PlayerId: 16, Name: "p", Surname: "p" },
    { TournamentEntryId: 17, PlayerId: 17, Name: "r", Surname: "r" },
    { TournamentEntryId: 18, PlayerId: 18, Name: "s", Surname: "s" }
  ];


  // main draw is always symmetric, only used to check loosers-draw
  isSymmetricDraw(count: number): boolean {
    if (count / 2 > 2) {
      this.isSymmetricDraw(count / 2);
    } else if (count % 2 > 1) {
      return false;
    } else {
      return true;
    }
  }

  isEven(index: number): boolean {
    return index % 2 > 0 ? true : false;
  }

  addQualifier() {
    console.log("aqq");
  }

  createDraw() {
    // -------------------------------------- !!!!!! change after TESTING to minimum number of players
    if (this.acceptedPlayers.length >= 0) {
      this.tryGetDataByArgs<MatchDTO[], CreateOrUpdateMatchesArgs>({
        apiMethod: this.matchClient.createOrUpdateMatches,
        showError: true,
        requestArgs: {
          TournamentId: this.tournamentId,
          DrawSize: this.draw,
          Matches: this.matches
        }
      }).then((response) => {
        if (response.ok) {
          this.matches = response.data;
        }
      });
    } else {
      NotificationUtils.ShowErrorMessage("There is not enough accepted players to create draw.");
    }
  }

  deleteDraw(): void {
    console.log("draw deleted");
    // spravit nejaku normalnu api methodu na delete try delete abo neco s akceptovanim id
    this.tryGetDataByArgs<void, MatchesArgs>({
      apiMethod: this.matchClient.deleteTournamentMatchesGraph,
      showError: true,
      requestArgs: { TournamentId: this.tournamentId }
    }).then((resp) => {
      if (resp.ok) {
        NotificationUtils.ShowSuccess({
          message: "Tournament draw deleted",
          title: "Tournament Draw Delete"
        });
        this.matches = null;
      }
    });
  }

  // poriesit ako pridam matche pre prve kolo
  // pridat btn add qualifier/ delete qualifier
  created(): void {
    this.isEdit = this.isEditablePage;
    this.matches = [];
    if (this.tournamentMatches.length > 0) {
      this.matches = this.tournamentMatches;
    }

    if (this.acceptedPlayersProp != null) {
      this.playerCount = this.acceptedPlayersProp.length;
      this.acceptedPlayers = this.acceptedPlayersProp;
    }

    if (this.playerCount > DrawSize.draw32) {
      const qualificationCount = this.playerCount - DrawSize.draw32;
      if (qualificationCount > DrawSize.draw32 / 2) this.draw = DrawSize.draw64;
      else {
        this.draw = DrawSize.draw32;
        this.isQualification = true;
      }
    } else if (this.playerCount > DrawSize.draw16) {
      const qualificationCount = this.playerCount - DrawSize.draw16;
      if (qualificationCount > DrawSize.draw16 / 2) this.draw = DrawSize.draw32;
      else {
        this.draw = DrawSize.draw16;
        this.isQualification = true;
      }
    }
  }
}
</script>

<style lang="scss" scoped>
@import "@/styles/views/tournament/tournament-draw.scss";
</style>

// draw spravit ppodla roundu, velkost roundu podla draw, qualification podla poctu accepted players, TODO urcit velkosti screenov, base 1250, TODO pozriet preco sa neupdatuje matches na tournamentdraw componente cize tu :)
//TODO sprav najprv commit
