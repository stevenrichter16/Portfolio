/*
 * Steven Richter
 * UW Oshkosh
 * CS 346
 * Wishlist Application
 */
package com.example.gui;

import androidx.appcompat.app.AppCompatActivity;
import androidx.localbroadcastmanager.content.LocalBroadcastManager;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.content.res.Configuration;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;


import static com.example.gui.LoginActivity.my_key;

public class FeedActivity extends AppCompatActivity {
    public static final String items_json = "ITEMS_JSON";
    public static String update_feed = "UPDATE_FEED";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if(getResources().getConfiguration().orientation==
                Configuration.ORIENTATION_LANDSCAPE) {
            setContentView(R.layout.feed_landscape);
        } else{
            setContentView(R.layout.feed);
        }


        startTheService();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        Intent intent = new Intent(this, MyIntentService.class);
        stopService(intent);
    }


    private class ReceiverClass extends BroadcastReceiver {
        public void onReceive(Context context, Intent intent){
            String items = intent.getStringExtra(items_json);
            String update_feed = intent.getStringExtra(FeedActivity.update_feed);
            if (update_feed.equals("yes") || update_feed.equals("no")) {
                try {
                    JSONArray items_array = new JSONArray(items);
                    for(int i=0; i<items_array.length(); i++){
                        JSONObject jso = items_array.getJSONObject(i);
                        String u_name = jso.getString("u_name");
                        String item_name = jso.getString("item_name");
                        String item_price = String.valueOf(jso.getDouble("item_price"));
                        addRow(item_name, item_price, u_name);
                    }
                }
                catch (JSONException j) {
                    makeToast("Couldn't get items");
                }
            }
        }
    }

    public void startTheService(){
        IntentFilter intentFilter = new IntentFilter("someString");
        ReceiverClass receiverClass = new ReceiverClass();
        LocalBroadcastManager.getInstance(this).registerReceiver(receiverClass, intentFilter);
        Intent intent = new Intent(this, MyIntentService.class);
        startService(intent);
    }

    public void addRow(String itemName, String itemPrice, String username) {
        // Get parent layout that will hold all items
        LinearLayout parentLayout = findViewById(R.id.itemList);

        // Create layout for new item
        LinearLayout l = new LinearLayout(this);
        l.setOrientation(LinearLayout.HORIZONTAL);
        LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, 100);
        layoutParams.bottomMargin = 10;
        l.setBackgroundResource(R.drawable.customborder);
        l.setLayoutParams(layoutParams);

        // Create item_name textview
        TextView name_textview = new TextView(this);
        name_textview.setText(itemName);
        name_textview.setTextSize(24);
        LinearLayout.LayoutParams nameParams = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.MATCH_PARENT);
        nameParams.weight = 1;
        name_textview.setLayoutParams(nameParams);

        // Create price textview
        TextView price_textview = new TextView(this);
        price_textview.setText("$"+itemPrice);
        price_textview.setTextSize(24);
        LinearLayout.LayoutParams priceParams = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.MATCH_PARENT);
        priceParams.weight = 1;
        price_textview.setLayoutParams(priceParams);

        // Create username textview
        TextView username_textview = new TextView(this);
        username_textview.setText(username);
        username_textview.setTextSize(24);
        LinearLayout.LayoutParams usernameParams = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.MATCH_PARENT);
        usernameParams.weight = 1;
        username_textview.setLayoutParams(usernameParams);

        // Add views to layout
        l.addView(name_textview);
        l.addView(price_textview);
        l.addView(username_textview);
        parentLayout.addView(l);

    }

    public void goToHome(View view) {
        Intent intent = new Intent(this, WishlistActivity.class);
        // assign a value to my_key
        SharedPreferences sp = getSharedPreferences("com.example.gui", Context.MODE_PRIVATE);
        String username = sp.getString("username",null);
        intent.putExtra(my_key, username);
        Intent stopIntent = new Intent(this, MyIntentService.class);
        stopService(stopIntent);
        startActivity(intent);
    }

    public void logout(View view) {
        startActivity(new Intent(FeedActivity.this, LoginActivity.class));
    }

    public void makeToast(String string) {
        Context context = getApplicationContext();
        CharSequence text = string;
        int duration = Toast.LENGTH_SHORT;

        Toast toast = Toast.makeText(context, text, duration);
        toast.show();
    }
}
