package com.example.gui;

import android.app.IntentService;
import android.content.Intent;
import android.content.Context;
import android.content.SharedPreferences;
import android.widget.Toast;

import androidx.localbroadcastmanager.content.LocalBroadcastManager;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class MyIntentService extends IntentService {
    public static int count = 0;
    public static int oldCount = 0;

    public MyIntentService() {
        super("MyIntentService");
    }

    private void doWork(){
        // Get items of other users
            SharedPreferences sp = getSharedPreferences("com.example.gui", Context.MODE_PRIVATE);
            String username = sp.getString("username", null);

            RequestQueue queue = Volley.newRequestQueue(this);
            String url = "http://3.218.138.116/feedItems.php?u_name=" + username;
            JsonArrayRequest stringRequest = new
                    JsonArrayRequest(Request.Method.GET, url, null,
                    new Response.Listener<JSONArray>() {
                        public void onResponse(JSONArray response) {
                            if (response.length() != 0) {
                                //service does a bunch of work
                                Intent intent = new Intent("someString");

                                String itemsJson = response.toString();
                                oldCount = count;
                                count = itemsJson.length();

                                if (oldCount != count) {
                                    intent.putExtra(FeedActivity.update_feed, "yes");
                                }
                                else {
                                    intent.putExtra(FeedActivity.update_feed, "no");
                                }

                                intent.putExtra(FeedActivity.items_json, response.toString());
                                LocalBroadcastManager.getInstance(getContext()).sendBroadcast(intent);
                            } else {
                                makeToast("No items to get");
                            }
                        }
                    }, new Response.ErrorListener() {
                public void onErrorResponse(VolleyError er) {
                    makeToast("Error getting json data");
                }
            }
            );
            queue.add(stringRequest);
    }

    public Context getContext() {
        return this.getApplicationContext();
    }

    public void makeToast(String string) {
        Context context = getApplicationContext();
        CharSequence text = string;
        int duration = Toast.LENGTH_SHORT;

        Toast toast = Toast.makeText(context, text, duration);
        toast.show();
    }

    @Override
    protected void onHandleIntent(Intent intent) {
        if (intent != null) {
            doWork();
        }
    }
}
