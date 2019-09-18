#FROM node:10 as build-env
#WORKDIR /app

# Copy Everything to the build environment
#COPY . ./
#RUN npm i
#RUN npm run build:prod

FROM nginx
RUN rm -rf /usr/share/nginx/html/*

COPY nginx/nginx.conf /etc/nginx/sites-enabled/app.tea-collection.conf
COPY  dist/tea-collection-app /usr/share/nginx/html
# --from=build-env
EXPOSE 80
