<template>
  <div class="sign-in-page-data">
    <div class="sign-in-from w-100 m-auto pt-5">
    <h4 class="mt-3 text-white mb-0 text-center">Hi ! Michael Smith</h4>
    <p class="text-white text-center">Enter your password to access the admin.</p>
    <form class="mt-4">

      <div class="form-group">
        <label for="exampleInputEmail1">Password</label>
        <input type="Password" class="form-control mb-0" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Password">
      </div>

      <div class="d-inline-block w-100">
        <router-link tag="button" to="/auth/sign-in1" class="btn btn-primary float-right">Log In</router-link>
      </div>

    </form>
  </div>
  </div>
</template>
<script>
export default {
  name: 'LockScreen1'
}
</script>
