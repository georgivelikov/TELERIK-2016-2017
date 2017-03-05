package com.telerikacademy.meetup.view.nearby_venues;

import android.content.Context;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Filter;
import android.widget.Filterable;
import android.widget.RatingBar;
import android.widget.TextView;
import butterknife.BindView;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.model.Venue;
import com.telerikacademy.meetup.model.base.IVenue;
import com.telerikacademy.meetup.view.venue_details.VenueDetailsActivity;

import java.util.ArrayList;
import java.util.List;

public class NearbyVenuesAdapter
        extends RecyclerView.Adapter<NearbyVenuesAdapter.VenueHolder>
        implements Filterable {

    private static final String EXTRA_CURRENT_VENUE_ID =
            VenueDetailsActivity.class.getCanonicalName() + ".CURRENT_VENUE_ID";

    @BindView(R.id.tv_empty)
    TextView textViewEmpty;

    private List<IVenue> venues;
    private List<IVenue> filteredVenues;

    private VenueFilter venueFilter;

    public NearbyVenuesAdapter(List<IVenue> venues) {
        this.venues = venues;
        filteredVenues = new ArrayList<>(this.venues);
    }

    public void swapData(List<IVenue> venues) {
        this.venues.clear();
        this.venues.addAll(venues);
        filteredVenues = new ArrayList<>(this.venues);
        notifyDataSetChanged();
    }

    @Override
    public VenueHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.rv_nearby_venue_item_row, parent, false);
        return new VenueHolder(view);
    }

    @Override
    public void onBindViewHolder(VenueHolder holder, int position) {
        IVenue venue = filteredVenues.get(position);
        holder.bindVenue(venue);
    }

    @Override
    public int getItemCount() {
        return filteredVenues.size();
    }

    @Override
    public Filter getFilter() {
        if (venueFilter == null) {
            venueFilter = new VenueFilter(this, venues);
        }

        return venueFilter;
    }

    static class VenueHolder extends RecyclerView.ViewHolder
            implements View.OnClickListener {

        @BindView(R.id.venue_name)
        TextView venueName;
        @BindView(R.id.venue_types)
        TextView venueTypes;
        @BindView(R.id.venue_address)
        TextView venueAddress;
        @BindView(R.id.venue_rating)
        RatingBar venueRating;

        private IVenue venue;

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
            showVenueIntent.putExtra(EXTRA_CURRENT_VENUE_ID, venue.getId());

            context.startActivity(showVenueIntent);
        }

        void bindVenue(IVenue venue) {
            this.venue = venue;
            venueName.setText(venue.getName());
            venueAddress.setText(venue.getAddress());
            venueRating.setRating(venue.getRating());

            if (venue.getTypes() != null) {
                venueTypes.setText(TextUtils.join(", ", venue.getTypes()));
            }
        }
    }

    private class VenueFilter extends Filter {

        private NearbyVenuesAdapter adapter;
        private List<IVenue> originalList;
        private List<IVenue> filteredList;

        private VenueFilter(NearbyVenuesAdapter adapter, List<IVenue> venues) {
            super();
            this.adapter = adapter;
            originalList = venues;
            filteredList = new ArrayList<>();
        }

        @Override
        protected FilterResults performFiltering(CharSequence constraint) {
            filteredList.clear();

            final FilterResults results = new FilterResults();

            if (constraint.length() == 0) {
                filteredList.addAll(originalList);
            } else {
                final String filterPattern = constraint.toString().toLowerCase().trim();

                for (final IVenue venue : originalList) {
                    String venueName = venue.getName();
                    if (venueName != null &&
                            venueName.toLowerCase().contains(filterPattern)) {
                        filteredList.add(venue);
                    }
                }
            }

            results.values = filteredList;
            results.count = filteredList.size();
            return results;
        }

        @Override
        @SuppressWarnings("unchecked")
        protected void publishResults(CharSequence constraint, FilterResults results) {
            adapter.filteredVenues.clear();
            adapter.filteredVenues.addAll((ArrayList<Venue>) results.values);
            adapter.notifyDataSetChanged();
        }
    }
}
