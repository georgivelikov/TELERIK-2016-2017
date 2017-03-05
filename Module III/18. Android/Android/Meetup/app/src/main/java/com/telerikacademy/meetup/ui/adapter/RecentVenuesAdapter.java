package com.telerikacademy.meetup.ui.adapter;

import android.content.Context;
import android.content.Intent;
import android.support.v7.widget.PopupMenu;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.RatingBar;
import android.widget.TextView;
import butterknife.BindView;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.model.base.IVenue;
import com.telerikacademy.meetup.util.base.IUserSession;
import com.telerikacademy.meetup.view.venue_details.VenueDetailsActivity;

import java.util.List;

public class RecentVenuesAdapter extends RecyclerView.Adapter<RecentVenuesAdapter.VenueHolder> {

    private static final String EXTRA_CURRENT_VENUE_ID =
            VenueDetailsActivity.class.getCanonicalName() + ".CURRENT_VENUE_ID";

    private final IUserSession userSession;
    private final List<IVenue> venues;

    public RecentVenuesAdapter(IUserSession userSession, List<IVenue> venues) {
        this.userSession = userSession;
        this.venues = venues;
    }

    @Override
    public VenueHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.rv_recent_venue_item_row, parent, false);
        return new VenueHolder(view, userSession);
    }

    @Override
    public void onBindViewHolder(VenueHolder holder, int position) {
        IVenue venue = venues.get(position);
        holder.bindVenue(venue);
    }

    @Override
    public int getItemCount() {
        return venues.size();
    }

    public void swap(List<IVenue> venues) {
        this.venues.clear();
        this.venues.addAll(venues);
        notifyDataSetChanged();
    }

    public void add(List<IVenue> venues) {
        this.venues.addAll(venues);
        notifyDataSetChanged();
    }

    static class VenueHolder extends RecyclerView.ViewHolder
            implements View.OnClickListener, View.OnLongClickListener {

        @BindView(R.id.iv_recent_venues_photo)
        ImageView venuePhoto;
        @BindView(R.id.tv_recent_venues_name)
        TextView venueName;
        @BindView(R.id.rb_recent_venues_rating)
        RatingBar venueRating;

        private final IUserSession userSession;
        private IVenue venue;

        public VenueHolder(View itemView, IUserSession userSession) {
            super(itemView);
            this.userSession = userSession;
            BaseApplication.bind(this, itemView);
            itemView.setOnLongClickListener(this);
            itemView.setOnClickListener(this);
        }

        @Override
        public void onClick(View v) {
            Context context = itemView.getContext();

            Intent showVenueIntent = new Intent(context, VenueDetailsActivity.class);
            showVenueIntent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
            showVenueIntent.putExtra(EXTRA_CURRENT_VENUE_ID, venue.getId());

            context.startActivity(showVenueIntent);
        }

        @Override
        public boolean onLongClick(final View v) {
            PopupMenu popupMenu = new PopupMenu(itemView.getContext(), itemView);
            popupMenu.inflate(R.menu.popup_recently_viewed);

            if (!userSession.isUserLoggedIn()) {
                popupMenu.getMenu().removeItem(R.id.action_save);
            }

            popupMenu.setOnMenuItemClickListener(new PopupMenu.OnMenuItemClickListener() {
                @Override
                public boolean onMenuItemClick(MenuItem item) {
                    switch (item.getItemId()) {
                        case R.id.action_open:
                            onClick(v);
                            break;
                    }

                    return false;
                }
            });

            popupMenu.show();
            return false;
        }

        public void bindVenue(IVenue venue) {
            this.venue = venue;
            venuePhoto.setImageBitmap(venue.getPhoto());
            venueName.setText(venue.getName());
            venueRating.setRating(venue.getRating());
        }
    }
}
