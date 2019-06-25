<template>
  <div>
    <h1>Teeeeeeeeeeeest!</h1>
    <d-button @click="handleClick">Click me!</d-button>
      <d-button @click="handleClick">Click 2 me!</d-button>
      <d-alert dismissible theme="light" :show="showAlert" @alert-dismissed="siChuj">No co jeeeeeeeee</d-alert>
      <div>
        <d-navbar toggleable="lg">
          <d-navbar-nav v-bind:justified="true" >  
              <d-nav-item to="/">Turnaje</d-nav-item>
              <d-nav-item to="/" >Rebríčky</d-nav-item>
              <d-nav-item to="/players" >Hráči</d-nav-item>
          </d-navbar-nav>
        </d-navbar>
      </div>
  </div>
</template>

<script>
// import dButton from '../src/components/button/Button'
// import dAlert from '../src/components/alert/Alert'

export default {
    name: 'test',
components: {
        // dButton,
        // dAlert
        
    },
    data() {
        return {
            showAlert: false,
            isDismisable: true
        }
    },
    methods: {
        handleClick() {
            this.showAlert = true;
        },
        siChuj() {
            this.showAlert = false;
        },
        onNavClicked(){
            
        }
    }
}
</script>
