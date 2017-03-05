package com.telerikacademy.meetup.view.favorite_venues;

import android.content.Context;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import butterknife.BindView;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.model.base.IVenueShort;
import com.telerikacademy.meetup.view.venue_details.VenueDetailsActivity;

import java.util.List;

public class FavoriteVenuesAdapter extends RecyclerView.Adapter<FavoriteVenuesAdapter.VenueHolder> {

    private static final String EXTRA_CURRENT_VENUE_ID =
            VenueDetailsActivity.class.getCanonicalName() + ".CURRENT_VENUE_ID";

    private List<IVenueShort> venues;

    public FavoriteVenuesAdapter(List<IVenueShort> venues) {
        this.venues = venues;
    }

    @Override
    public VenueHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.rv_favorite_item_row, parent, false);
        return new VenueHolder(view);
    }

    @Override
    public void onBindViewHolder(VenueHolder holder, int position) {
        IVenueShort venue = venues.get(position);
        holder.bindVenue(venue);
    }

    @Override
    public int getItemCount() {
        return venues.size();
    }

    public void swap(List<? extends IVenueShort> venues) {
        this.venues.clear();
        this.venues.addAll(venues);
        notifyDataSetChanged();
    }

    static class VenueHolder extends RecyclerView.ViewHolder
            implements View.OnClickListener {

        @BindView(R.id.tv_favorite_venue_name)
        TextView venueName;
        @BindView(R.id.tv_favorite_venue_address)
        TextView venueAddress;

        private IVenueShort currentVenue;

        private VenueHolder(View itemView) {
            super(itemView);
            BaseApplication.bind(this, itemView);
            itemView.setOnClickListener(this);
        }

        @Override
        public void onClick(View v) {
            Context context = itemView.getContext();

            Intent showVenueIntent = new Intent(context, VenueDetailsActivity.class);
            showVenueIntent.addFlags(Intent.FLAG_ACTIVITY_REORDER_TO_FRONT);
            showVenueIntent.putExtra(EXTRA_CURRENT_VENUE_ID, currentVenue.getGoogleId());

            context.startActivity(showVenueIntent);
        }

        void bindVenue(IVenueShort venue) {
            currentVenue = venue;
            venueName.setText(venue.getName());
            venueAddress.setText(venue.getAddress());
        }
    }
}
