FROM nginx
RUN rm -rf /usr/share/nginx/html/*

COPY nginx/nginx.conf /etc/nginx/nginx.conf
COPY dist/tea-collection-app /usr/share/nginx/html
EXPOSE 80
