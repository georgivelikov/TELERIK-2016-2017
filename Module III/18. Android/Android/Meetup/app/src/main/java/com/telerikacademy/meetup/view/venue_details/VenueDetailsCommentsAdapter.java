package com.telerikacademy.meetup.view.venue_details;

import android.support.v7.widget.RecyclerView;
import android.text.format.DateUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import butterknife.BindView;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.model.base.IComment;

import java.util.List;

public class VenueDetailsCommentsAdapter extends RecyclerView.Adapter<VenueDetailsCommentsAdapter.CommentHolder> {

    private List<IComment> comments;

    public VenueDetailsCommentsAdapter(List<IComment> comments) {
        this.comments = comments;
    }

    @Override
    public CommentHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.rv_comments_item_row, parent, false);
        return new CommentHolder(view);
    }

    @Override
    public void onBindViewHolder(CommentHolder holder, int position) {
        IComment comment = comments.get(position);
        holder.bindComment(comment);
    }

    @Override
    public int getItemCount() {
        return comments.size();
    }

    public void add(List<? extends IComment> comments) {
        this.comments.addAll(comments);
        notifyDataSetChanged();
    }

    public void swap(List<? extends IComment> comments) {
        this.comments.clear();
        this.comments.addAll(comments);
        notifyDataSetChanged();
    }

    static class CommentHolder extends RecyclerView.ViewHolder
            implements View.OnLongClickListener {

        @BindView(R.id.tv_comment_username)
        TextView usernameTextView;
        @BindView(R.id.tv_comment_date)
        TextView postDateTextView;
        @BindView(R.id.tv_comment_content)
        TextView contentTextView;

        public CommentHolder(View itemView) {
            super(itemView);
            BaseApplication.bind(this, itemView);
            itemView.setOnLongClickListener(this);
        }

        public void bindComment(IComment comment) {
            CharSequence relativeDate = DateUtils.getRelativeDateTimeString(
                    itemView.getContext(), comment.getPostDate().getTime(),
                    DateUtils.MINUTE_IN_MILLIS, DateUtils.YEAR_IN_MILLIS, 0);

            usernameTextView.setText(comment.getAuthorUsername());
            postDateTextView.setText(relativeDate);
            contentTextView.setText(comment.getContent());
        }

        @Override
        public boolean onLongClick(View v) {
            return false;
        }
    }
}
