/*
 * Steven Richter
 * UW Oshkosh
 * CS 346
 * Wishlist Application
 */
package com.example.gui;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Configuration;
import android.os.Bundle;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import java.util.regex.Pattern;

public class LoginActivity extends AppCompatActivity {
    public static final String my_key = "USERNAME";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if(getResources().getConfiguration().orientation==
                Configuration.ORIENTATION_LANDSCAPE) {
            setContentView(R.layout.login_landscape);
        } else{
            setContentView(R.layout.login);
        }
        //this leaves the keyboard hidden on load
        getWindow().setSoftInputMode(
                WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
        SharedPreferences sp = getSharedPreferences("com.example.gui",Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = sp.edit();
        editor.clear();
        editor.apply();
    }

    public void changeButton(View view) {
        // Get checkbox
        CheckBox checkBox = (CheckBox) view;

        // Get button
        View buttonView = findViewById(R.id.button7);
        Button button = (Button) buttonView;

        if (checkBox.isChecked()) {
            button.setText(R.string.log_in);
        }

        else {
            button.setText("Register");
        }
    }

    /* Called when the button is clicked */
    public void Submit(View view) {
        Boolean canRegister = false;
        Boolean canLogin = false;

        // Get the button
        Button button = (Button) view;

        // Get Username Text
        View usernameView = findViewById(R.id.editText);
        EditText userEditText = (EditText) usernameView;
        String username = userEditText.getText().toString();

        // Get Password Text
        View passwordView = findViewById(R.id.editText2);
        EditText passEditText = (EditText) passwordView;
        String password = passEditText.getText().toString();

        // Distinguish if button says Log In or Registering
        Boolean registering;
        String buttonText = button.getText().toString();

        if (buttonText.equals("Register")) {
            registering = true;
        }
        else {
            registering = false;
        }

        // If registering
        if (registering) {
            checkRegisterConditions(username, password);
        }

        // If logging in
        else {
            checkLoginConditions(username, password);
        }
        return;
    }

    public void goToNextActivity(String username) {
        // initialize activity
        Intent intent = new Intent(this, WishlistActivity.class);

        // assign a value to my_key
        intent.putExtra(my_key, username);

        // start activity
        startActivity(intent);
    }

    /* Checks username and password if user is registering */
    public void checkRegisterConditions(final String username, final String password) {
        boolean lowerCaseMatch = false;
        boolean upperCaseMatch = false;
        boolean numberMatch = false;

        // check username >= 4 chars
        if (username.length() < 4) {
            makeToast("ERROR: username < 4 characters");
            return;
        }

        if (password.length() >= 6) {
            Pattern pLower = Pattern.compile("(.?)+[a-z](.?)+");
            lowerCaseMatch = pLower.matcher(password).matches();

            // check password contains [A-Z]
            Pattern pUpper = Pattern.compile("(.?)+[A-Z](.?)+");
            upperCaseMatch = pUpper.matcher(password).matches();

            // check password contains [0-9]
            Pattern pNum = Pattern.compile("(.?)+[0-9](.?)+");
            numberMatch = pNum.matcher(password).matches();


            if (lowerCaseMatch) {
                if (upperCaseMatch) {
                    if (numberMatch) {
                        RequestQueue queue = Volley.newRequestQueue(this);
                        String url = "http://3.218.138.116/checkRegister.php?u_name="+username;
                        StringRequest stringRequest = new
                                StringRequest(Request.Method.GET, url,
                                new Response.Listener<String>() {
                                    public void onResponse(String response){
                                        if (response.length() == 0) {
                                            register(username, password);
                                        }
                                        else {
                                            makeToast("Username already exists");
                                            return;
                                        }
                                    }
                                }, new Response.ErrorListener() {
                            public void onErrorResponse(VolleyError er){
                                makeToast("Error registering");
                            }
                        }
                        ); queue.add(stringRequest);
                    }
                }
            }

        }
        if (!(lowerCaseMatch && upperCaseMatch && numberMatch)) {
            makeToast("Password does not contain [a-zA-Z0-9] and/or is not at least 6 characters");
        }
        return;
    }

    public void register(String username, String password) {
        RequestQueue queue = Volley.newRequestQueue(this);
        String url = "http://3.218.138.116/insert.php?u_name="+username+"&p_word="+password;
        StringRequest stringRequest = new
                StringRequest(Request.Method.GET, url,
                new Response.Listener<String>() {
                    public void onResponse(String response){
                        makeToast("Successfully registered");
                    }
                }, new Response.ErrorListener() {
            public void onErrorResponse(VolleyError er){
                makeToast("Something went wrong");
            }
        }
        ); queue.add(stringRequest);

        goToNextActivity(username);
    }

    public void checkLoginConditions(final String username, final String password) {
        RequestQueue queue = Volley.newRequestQueue(this);
        String url = "http://3.218.138.116/checkLogin.php?u_name="+username+"&p_word="+password;
        StringRequest stringRequest = new
                StringRequest(Request.Method.GET, url,
                new Response.Listener<String>() {
                    public void onResponse(String response){
                        if (response.length() != 0) {
                            goToNextActivity(username);
                        }
                        else {
                            makeToast("Incorrect username or password");
                        }
                    }
                }, new Response.ErrorListener() {
            public void onErrorResponse(VolleyError er){
                makeToast("Error");
            }
        }
        ); queue.add(stringRequest);
    }

    public void makeToast(String string) {
        Context context = getApplicationContext();
        CharSequence text = string;
        int duration = Toast.LENGTH_SHORT;

        Toast toast = Toast.makeText(context, text, duration);
        toast.show();
    }
}
