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
      <div v-if="!existsDraw()" class="select-draw-size">
        <label for="drawSize">{{ "Draw Size" }}</label>
        <d-form-select id="drawSize" v-model="drawSize" :options="tournamentHelper.GetTournamentDrawSizes()" :value="drawSize" />
      </div>
      <!-- <div class="draw-matches-16">
        <section class="matches show-only-on-large-size round1">
        </section>
        <section class="matches show-only-on-large-size round2">
          <ul class="opponents">
            <li>
            </li>
          </ul>
        </section>
      </div> -->
      <div >
        <div v-if="existsDraw()" class="bracket">
          <!-- <tournament-draw-round v-if="isQualification(null)" :roundMatchProp="getQualificationRound()"></tournament-draw-round> -->
          <tournament-draw-round v-for="(round) in rounds" :key="round.Round" :roundMatchProp="round"></tournament-draw-round>
        </div>
        // vymazat webkit ... pokrracovat v css code
        <d-btn @click="createDraw">{{ createOrUpdateTxtBtn()  }}</d-btn>
        <d-btn style="margin-left: 0.5%" v-if="existsDraw()" @click="deleteDraw">Delete</d-btn>
      </div>
    </div>
  </div>
</template>

<script lang="ts">

import { BaseComponentClass } from "../../common/BaseComponentClass";
import Component from "vue-class-component";
import { Prop, Watch } from "vue-property-decorator";
import {
  PlayerDrawDTO,
  TournamentRound
} from "../../Api/TournamentEntryController";
import MatchClient, {
  MatchDTO,
  MatchesArgs,
  DrawSize,
  CreateOrUpdateMatchesArgs,
  DrawDTO,
  RoundMatchDTO
} from "../../Api/MatchController";
import { TournamentHelper } from "./tournamentHelper";
import { NotificationUtils } from "../../common/notification";
import TournamentDrawRound from "./tournament-draw/tournament-draw-round.vue";
import { MatchEntryDTO } from '../../Api/TournamentController';

export interface QualificationOrder{
  order: number,
  entry: number
}

export interface Round {
  isQualification: boolean,
  isFirstRound: boolean,
  roundMatch: RoundMatchDTO
}

@Component({
  components: {
    TournamentDrawRound
  }
})
export default class TournamentDraw extends BaseComponentClass {
  @Prop() readonly acceptedPlayersProp: PlayerDrawDTO[];
  @Prop() readonly tournamentDraw: DrawDTO;
  @Prop() readonly tournamentId: number;
  @Prop() readonly startingRoundProp: number;
  @Prop() readonly isEditablePage: boolean;

  acceptedPlayers: PlayerDrawDTO[] = [];
  tournamentHelper = TournamentHelper;
  matchClient: MatchClient = new MatchClient();
  draw: DrawDTO = null;
  rounds: Round[] = [];
  // startingRound: number;

  isEdit = false;
  playerCount = 0;
  drawSize: DrawSize = DrawSize.draw32;
  // isQualification = false;

  @Watch("tournamentDraw")
  ontournamentDrawPropChange(tournamentDraw: DrawDTO): void {
    this.draw = tournamentDraw;
    console.log('calling draw change')
    this.roundsInit(this.draw);
  }

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

  createDraw() {
    // correct MatchDTO[] to DrawDTO on all modified controllers
    // -------------------------------------- !!!!!! change after TESTING to minimum number of players
    if (this.acceptedPlayers.length >= 0) {
      this.tryGetDataByArgs<DrawDTO, CreateOrUpdateMatchesArgs>({
        apiMethod: this.matchClient.createOrUpdateMatches,
        showError: true,
        requestArgs: {
          TournamentId: this.tournamentId,
          DrawSize: this.drawSize,
          Matches: this.draw?.RoundMatches?.flatMap(m => m.Matches)
        }
      }).then((response) => {
        if (response.ok) {
          // this.matches = response.data;

          // hub not working in Vue component why?
          this.$eventHub.$emit('createDrawEventOnHub', response.data);
          // this.$emit("createDrawEvent", response.data);
        }
      });
    } else {
      NotificationUtils.ShowErrorMessage("There is not enough accepted players to create draw.");
    }
  }

  getClassByRound(round: TournamentRound): string {
    let roundClass = "";
    switch (round) {
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

  // implementuj cez event bus
  deleteDraw(): void {
    this.$emit('tournamentDrawDelete', this.tournamentId);
  }

  existsDraw(): boolean {
    return this.draw?.RoundMatches?.length > 1;
  }

  createOrUpdateTxtBtn(): string {
    return this.existsDraw() ? "Update" : "Create";
  }

  isQualification() {
    if (this.existsDraw) {
      if (this.draw.RoundMatches[0].Matches.length < this.draw.RoundMatches[1].Matches.length * 2) {
        // if(this.draw.RoundMatches[0].Round == roundMatch.Round){
        return true;
        // }
      }
    }
    return false;
  }

  // namiesto toho aby som posielal jak chuj vsetko cez metody,
  // sprav taky objekt ktory bude mat inicializovany cely round s datami ktore potrebujes napr. isQualification, isFirstRound, matches (t.j. aj inicializovane qualificationMatches)
  // kedze matches budu mapovane a budu referencovat draw Round matches kludne mozes poslat svoj objekt s referenciami na draw object, vo vues sa ti to automaticky zmeni
  isFirstRound(roundMatch: RoundMatchDTO): boolean {
    if (this.isQualification()) {
      return this.draw.RoundMatches[1].Round == roundMatch.Round;
    } else {
      return this.draw.RoundMatches[0].Round == roundMatch.Round;
    }
  }

  isQualificationRound(roundMatch: RoundMatchDTO) {
    if (this.existsDraw) {
      if (this.draw.RoundMatches[0].Matches.length < this.draw.RoundMatches[1].Matches.length * 2) {
        return this.draw.RoundMatches[0].Round == roundMatch.Round;
      }
      // else {
      //   return this.draw.RoundMatches[0].Round == roundMatch.Round;
      // }
    }
    return false;
  }

  getQualificationRound() {
    let roundMatch = new RoundMatchDTO();
    roundMatch.Round = this.draw.RoundMatches[0].Round;
    roundMatch.Matches = [];
    let qualificationRoundMatches = this.draw.RoundMatches[0].Matches.map(m => ({
      order: this.getQualificationMatchOrderCount(m),
      match: m
    }));
    const matchesCount = this.draw.RoundMatches[1].Matches.length * 2;
    for (let index = 0; index < matchesCount; index++) {
      if (qualificationRoundMatches.some(qm => qm.order == index)) {
        roundMatch.Matches.push(qualificationRoundMatches.filter(qm => qm.order == index)[0].match);
        continue;
      }
      let matchDto = new MatchDTO();
      matchDto.MatchEntries = [new MatchEntryDTO(), new MatchEntryDTO()];
      roundMatch.Matches.push(matchDto);
    }
    return roundMatch;
  }

  getQualificationMatchOrderCount(qualificationMatch: MatchDTO): number {
    let qualificationMatchOrder = 0;
    let entryOrder = 0;
    if (this.existsDraw) {
      // const firstRoundMatches = this.draw.RoundMatches[1].Matches.sort((mA, mB) => {
      //   if (mA.Id < mB.Id) return -1; else return 1;
      // })
      const matchOrder = this.draw.RoundMatches[1].Matches.findIndex((m) => {
      // const matchOrder = firstRoundMatches.findIndex((m) => {
        if (m.MatchEntries[0].ParentMatchId == qualificationMatch.Id) {
          return true;
        } else if (m.MatchEntries && m.MatchEntries.length > 1 && m.MatchEntries[1].ParentMatchId == qualificationMatch.Id) {
          entryOrder = 1;
          return true;
        } else false;
      });
      console.log(matchOrder);
      qualificationMatchOrder = matchOrder * 2 + entryOrder;
      console.log(qualificationMatchOrder)
    }

    return qualificationMatchOrder;
    // return { order: qualificationMatchOrder, entry: entryOrder};
  }

  roundsInit(draw: DrawDTO) {
    // let rounds: Round[] = [];

    if (this.draw?.RoundMatches?.length > 0) {
      this.draw.RoundMatches.forEach((roundMatch) => {
        let round: Round = {
          isQualification: false,
          isFirstRound: false,
          roundMatch: null
        };

        round.isQualification = this.isQualificationRound(roundMatch);
        round.isFirstRound = this.isFirstRound(roundMatch);

        if (round.isQualification) {
          round.roundMatch = this.getQualificationRound();
        } else {
          round.roundMatch = roundMatch;
        }

        this.rounds.push(round)
      });
    }

    // this.rounds = rounds;
  }

  // poriesit ako pridam matche pre prve kolo
  // pridat btn add qualifier/ delete qualifier
  created(): void {
    this.isEdit = this.isEditablePage;
    if (this.tournamentDraw.RoundMatches?.length > 0) {
      this.draw = this.tournamentDraw;
      this.roundsInit(this.draw);
    }

    if (this.acceptedPlayersProp != null) {
      this.playerCount = this.acceptedPlayersProp.length;
      this.acceptedPlayers = this.acceptedPlayersProp;
    }
  }
}
</script>

<style lang="scss" scoped>
@import "@/styles/views/tournament/tournament-bracket.scss";
</style>

// draw spravit ppodla roundu, velkost roundu podla draw, qualification podla poctu accepted players, TODO urcit velkosti screenov, base 1250
