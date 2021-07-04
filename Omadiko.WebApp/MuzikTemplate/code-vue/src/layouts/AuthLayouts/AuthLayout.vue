<template>
  <div>
    <Loader />
    <section class="sign-in-page">
      <b-container>
        <div class="row justify-content-center align-items-center height-self-center">
          <div class="col-md-6 col-sm-12 col-12 align-self-center">
            <div class="sign-user_card ">
              <div class="d-flex justify-content-center">
                <div class="sign-user_logo">
                  <b-img :src="userLogo" fluid alt="Logo"></b-img>
                </div>
              </div>
              <router-view></router-view>
            </div>
          </div>
        </div>
      </b-container>
    </section>
  </div>
</template>
<script>
import Loader from '../../components/core/loader/Loader'
import logo from '../../assets/images/logo.png'
import userLogo from '../../assets/images/login/user.png'
import { core } from '../../config/pluginInit'
import bgImage from '../../assets/images/login/login.jpg'
export default {
  name: 'AuthLayout',
  components: {
    Loader
  },
  mounted () {
    core.index()
  },
  data () {
    return {
      slickOptions: {
        slidesToShow: 1,
        arrows: false
      },
      logo: logo,
      bgImageURL: bgImage,
      userLogo: userLogo
    }
  }
}
</script>
<style>
  @import url("../../assets/css/custom.css");
</style>
