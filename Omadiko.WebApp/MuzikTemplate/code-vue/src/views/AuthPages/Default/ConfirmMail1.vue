<template>
  <div class="sign-in-page-data">
    <div class="sign-in-from w-100 m-auto pt-5">
    <img :src="require('../../../assets/images/login/mail.png')" width="80"  alt="">
    <h1 class="mt-3 mb-0">Success !</h1>
    <p class="text-white">A email has been send to youremail@domain.com. Please check for an email from company and click on the included link to reset your password.</p>
    <div class="d-inline-block w-100">

      <router-link tag="button" to="/home-1" class="btn btn-primary mt-3">Back to Home</router-link>
    </div>
    </div>
  </div>
</template>
<script>
export default {
  name: 'ConfirmMail1'
}
</script>
