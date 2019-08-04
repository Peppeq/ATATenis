<template>
    <div class="hello">
        <h1>{{ msg }}</h1>
        <h1>{{ reversedMsg() }}</h1>
        <p>
        </p>
        <!-- <p>{{players}} -->
        <!-- </p> -->
        <!-- <div v-for="player in players.players">
            {{player.name}}
        </div> -->
        <!-- <p>{{getPlayerNames}}</p> -->
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    @Component
    export default class HelloWorld extends Vue {
        @Prop() private msg!: string;

        mounted() {
            //  this.players = await testApi.getData().catch(() => 
            //  { alert('no nenatiahli sa data..')});
        }

        reversedMsg(): string {
            return this.msg.split('').reverse().join('')
        }

        //computed the same as method but have caching
        //computed: {
        //    getPlayerNames() {
        //        if (this.players != null && this.players.players != null) {
        //            // console.log(this.players);
        //            return this.players.players.map(p => { return p.name })
        //        }

        //        return null;
        //    }
            
        //},
        //setPlayerName: function (player) {
        //    this.player = player;
        //}
        //watch: {
        //    player: function (playerVal) {
        //        this.player = await testApi.getData();
        //    }
        //}
    }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }
</style>
