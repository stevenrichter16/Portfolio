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
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.regex.Pattern;

import static com.example.gui.LoginActivity.my_key;

public class WishlistActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if(getResources().getConfiguration().orientation==
                Configuration.ORIENTATION_LANDSCAPE) {
            setContentView(R.layout.wishlist_landscape);
        } else{
            setContentView(R.layout.wishlist);
        }

        // Get username from LoginActivity
        Intent intent = getIntent();
        String username = intent.getStringExtra(my_key);

        // Get textView2 and set text to username
        View usernameView = findViewById(R.id.textView2);
        TextView usernameTextView = (TextView) usernameView;
        usernameTextView.setText("Hi " + username);

        // Save username in sharedprefs
        SharedPreferences sp = getSharedPreferences("com.example.gui",Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = sp.edit();
        editor.putString("username",username);
        editor.commit();

        getWishlist();
    }

    public void getWishlist() {
        SharedPreferences sp = getSharedPreferences("com.example.gui",Context.MODE_PRIVATE);
        String username = sp.getString("username",null);

        RequestQueue queue = Volley.newRequestQueue(this);
        String url = "http://3.218.138.116/selectItem.php?u_name="+username;
        JsonArrayRequest stringRequest = new
                JsonArrayRequest(Request.Method.GET, url, null,
                new Response.Listener<JSONArray>() {
                    public void onResponse(JSONArray response){
                        if (response.length() != 0) {
                            try {
                                for(int i=0; i<response.length(); i++){
                                    JSONObject jso = response.getJSONObject(i);
                                    String item_name = jso.getString("item_name");
                                    String item_price = String.valueOf(jso.getDouble("item_price"));
                                    // Add item to screen
                                    addRow(item_name, item_price);
                                }
                            }

                            catch (JSONException j) {
                                System.out.println("JSON Error");
                            }
                        }
                        else {
                            makeToast("No items in your wishlist");
                        }
                    }
                }, new Response.ErrorListener() {
            public void onErrorResponse(VolleyError er){
                makeToast("Error connecting to database");
            }
        }
        ); queue.add(stringRequest);
    }

    public void goToFeed(View view) {
        // initialize activity
        Intent intent = new Intent(this, FeedActivity.class);
        SharedPreferences sp = getSharedPreferences("com.example.gui",Context.MODE_PRIVATE);
        String username = sp.getString("username",null);

        // assign a value to my_key
        intent.putExtra(my_key, username);

        // start activity
        startActivity(intent);
    }

    public void addItem(View v) {
        SharedPreferences sp = getSharedPreferences("com.example.gui",Context.MODE_PRIVATE);
        String username = sp.getString("username",null);

        // Get nametext
        final EditText editTextName = (EditText) findViewById(R.id.editTextName);
        final String itemName = editTextName.getText().toString();

        // Get pricetext
        EditText editTextPrice = (EditText) findViewById(R.id.editTextPrice);
        final String itemPrice = editTextPrice.getText().toString();
        Pattern pNum = Pattern.compile("^\\$?[0-9]+(\\.[0-9][0-9])?$");
        boolean numberMatch = pNum.matcher(itemPrice).matches();
        if (!numberMatch) {
            makeToast("Enter a valid dollar amount");
            return;
        }

        if (itemName.equals("") || itemPrice.equals("")) {
            makeToast("Fill out all fields");
            return;
        }

        // Add item to DB
        RequestQueue queue = Volley.newRequestQueue(this);
        String url = "http://3.218.138.116/insertItem.php?u_name="+username+"&item_name="+itemName.replace(" ","_")+"&item_price="+itemPrice;
        StringRequest stringRequest = new
                StringRequest(Request.Method.GET, url,
                new Response.Listener<String>() {
                    public void onResponse(String response){
                        makeToast("Item created");
                        updateTotal();
                    }
                }, new Response.ErrorListener() {
            public void onErrorResponse(VolleyError er){
                makeToast("Error: Item not created");
            }
        }
        ); queue.add(stringRequest);

        addRow(itemName, itemPrice);

        // Clear edittexts and clear focus
        editTextName.setText("");
        editTextPrice.setText("");
        editTextName.clearFocus();
        editTextPrice.clearFocus();
    }

    public void addRow(final String itemName, final String itemPrice) {
        // Get parent layout that will hold all items
        LinearLayout parentLayout = (LinearLayout) findViewById(R.id.itemList);

        // New layout for new item
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
        priceParams.weight = 0.5f;
        price_textview.setLayoutParams(priceParams);

        // Create vertical linearlayout for edit/delete buttons
        LinearLayout buttonL = new LinearLayout(this);
        buttonL.setOrientation(LinearLayout.HORIZONTAL);
        LinearLayout.LayoutParams buttonLayoutParams = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.MATCH_PARENT);
        buttonLayoutParams.weight = 0.35f;
        buttonL.setLayoutParams(buttonLayoutParams);

        ImageButton editB = new ImageButton(this);
        LinearLayout.LayoutParams editButtonParams = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.MATCH_PARENT);
        editButtonParams.weight = 0.5f;
        editB.setLayoutParams(editButtonParams);
        editB.setBackgroundResource(android.R.drawable.ic_menu_edit);
        editB.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ImageButton b = (ImageButton) v;
                LinearLayout parentLayout = (LinearLayout) b.getParent().getParent();
                LinearLayout mainLayout = (LinearLayout) parentLayout.getParent();
                mainLayout.removeView(parentLayout);

                View itemNameView = parentLayout.getChildAt(0);
                TextView itemNameTextView = (TextView) itemNameView;
                String _itemName = itemNameTextView.getText().toString();

                View itemPriceView = parentLayout.getChildAt(1);
                TextView itemPriceTextView = (TextView) itemPriceView;
                String _itemPrice = itemPriceTextView.getText().toString().replace("$","");

                editRow(v, _itemName, _itemPrice);
                updateTotal();
            }
        });

        // Create delete button
        ImageButton b = new ImageButton (this);
        LinearLayout.LayoutParams buttonParams = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.MATCH_PARENT);
        buttonParams.weight = 0.5f;
        b.setLayoutParams(buttonParams);
        b.setBackgroundResource(android.R.drawable.ic_menu_delete);
        b.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Delete row
                ImageButton b = (ImageButton) v;
                LinearLayout parentLayout = (LinearLayout) b.getParent().getParent();
                LinearLayout mainLayout = (LinearLayout) parentLayout.getParent();
                mainLayout.removeView(parentLayout);

                removeItem(itemName, itemPrice);
                updateTotal();

            }
        });

        l.addView(name_textview);
        l.addView(price_textview);
        l.addView(buttonL);
        buttonL.addView(editB);
        buttonL.addView(b);
        parentLayout.addView(l);
        updateTotal();
    }

    public void editRow(View v, final String itemName, final String itemPrice) {
        // Get parent layout that will hold all items
        LinearLayout parentLayout = (LinearLayout) findViewById(R.id.itemList);

        // New layout for new item
        LinearLayout l = new LinearLayout(this);
        l.setOrientation(LinearLayout.HORIZONTAL);
        LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, 100);
        layoutParams.bottomMargin = 10;
        l.setBackgroundResource(R.drawable.customborder);
        l.setLayoutParams(layoutParams);

        // Create item_name edittext
        EditText name_editText = new EditText(WishlistActivity.this);
        name_editText.setText(itemName);
        name_editText.setTextSize(24);
        LinearLayout.LayoutParams nameParams = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.MATCH_PARENT);
        nameParams.weight = 1;
        name_editText.setLayoutParams(nameParams);

        // Create price edittext
        EditText price_editText = new EditText(WishlistActivity.this);
        price_editText.setText(itemPrice);
        price_editText.setTextSize(24);
        LinearLayout.LayoutParams priceParams = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.MATCH_PARENT);
        priceParams.weight = 0.5f;
        price_editText.setLayoutParams(priceParams);

        // Create Save button
        ImageButton b = new ImageButton (this);
        LinearLayout.LayoutParams buttonParams = new LinearLayout.LayoutParams(0, ViewGroup.LayoutParams.MATCH_PARENT);
        buttonParams.weight = 0.17f;
        b.setLayoutParams(buttonParams);
        b.setBackgroundResource(android.R.drawable.ic_menu_save);
        b.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Save button
                ImageButton b = (ImageButton) v;

                // Get row linear layout
                LinearLayout parentLayout = (LinearLayout) b.getParent();

                // Get new item name
                View itemView = parentLayout.getChildAt(0);
                TextView newItemView = (TextView) itemView;
                String newItemName = newItemView.getText().toString();

                // Get new price
                View priceView = parentLayout.getChildAt(1);
                TextView newPriceView = (TextView) priceView;
                String newItemPrice = newPriceView.getText().toString();

                Pattern pNum = Pattern.compile("^\\$?[0-9]+(\\.[0-9][0-9])?$");
                boolean numberMatch = pNum.matcher(newItemPrice).matches();
                if (!numberMatch) {
                    makeToast("enter valid dollar amount");
                    return;
                }

                // Remove row
                LinearLayout mainLayout = (LinearLayout) parentLayout.getParent();
                mainLayout.removeView(parentLayout);

                // Update DB
                SharedPreferences sp = getSharedPreferences("com.example.gui",Context.MODE_PRIVATE);
                String username = sp.getString("username",null);

                RequestQueue queue = Volley.newRequestQueue(WishlistActivity.this);
                String url = "http://3.218.138.116/updateItem.php?u_name="+username+"&new_itemname="+newItemName.replace(" ","_")+"&new_itemprice="+newItemPrice+"&old_itemname="+itemName.replace(" ","_");
                StringRequest stringRequest = new
                        StringRequest(Request.Method.GET, url,
                        new Response.Listener<String>() {
                            public void onResponse(String response){
                                makeToast("Item updated");
                                updateTotal();
                            }
                        }, new Response.ErrorListener() {
                    public void onErrorResponse(VolleyError er){
                        makeToast("Not updated");
                    }
                }
                ); queue.add(stringRequest);

                // Add row with new values
                addRow(newItemName, newItemPrice);
                updateTotal();
            }
        });

        l.addView(name_editText);
        l.addView(price_editText);
        l.addView(b);
        parentLayout.addView(l);
        name_editText.requestFocus();
        updateTotal();
    }

    public void removeItem(String itemName, String itemPrice) {
        SharedPreferences sp = getSharedPreferences("com.example.gui",Context.MODE_PRIVATE);
        String username = sp.getString("username",null);

        RequestQueue queue = Volley.newRequestQueue(this);
        String url = "http://3.218.138.116/deleteItem.php?u_name="+username+"&item_name="+itemName.replace(" ","_");
        StringRequest stringRequest = new
                StringRequest(Request.Method.GET, url,
                new Response.Listener<String>() {
                    public void onResponse(String response){
                        makeToast("Item deleted");
                        updateTotal();
                    }
                }, new Response.ErrorListener() {
            public void onErrorResponse(VolleyError er){
                makeToast("Not deleted");
            }
        }
        ); queue.add(stringRequest);
        updateTotal();
    }

    public void updateTotal() {
        SharedPreferences sp = getSharedPreferences("com.example.gui",Context.MODE_PRIVATE);
        String username = sp.getString("username",null);

        RequestQueue queue = Volley.newRequestQueue(this);
        String url = "http://3.218.138.116/selectItem.php?u_name="+username;
        JsonArrayRequest stringRequest = new
                JsonArrayRequest(Request.Method.GET, url, null,
                new Response.Listener<JSONArray>() {
                    public void onResponse(JSONArray response){
                        if (response.length() != 0) {
                            double total = 0;
                            try {
                                for(int i=0; i<response.length(); i++){
                                    JSONObject jso = response.getJSONObject(i);
                                    double item_price = jso.getDouble("item_price");
                                    total += item_price;
                                }

                                // Update wishlist total (textview3)
                                View totalView = findViewById(R.id.textView3);
                                TextView totalTextView = (TextView) totalView;
                                totalTextView.setText("$"+total);
                            }
                            catch (JSONException j) {
                                System.out.println("JSON Error");
                            }
                        }
                        else {
                            // Update wishlist total (textview3)
                            double total = 0;
                            View totalView = findViewById(R.id.textView3);
                            TextView totalTextView = (TextView) totalView;
                            totalTextView.setText("$"+total);
                            makeToast("No items in your wishlist");
                        }
                    }
                }, new Response.ErrorListener() {
            public void onErrorResponse(VolleyError er){
                makeToast("Error updating wishlist total");
            }
        }
        ); queue.add(stringRequest);
    }

    public void logout(View v) {
        startActivity(new Intent(WishlistActivity.this, LoginActivity.class));
    }

    public void makeToast(String string) {
        Context context = getApplicationContext();
        CharSequence text = string;
        int duration = Toast.LENGTH_SHORT;

        Toast toast = Toast.makeText(context, text, duration);
        toast.show();
    }
}
