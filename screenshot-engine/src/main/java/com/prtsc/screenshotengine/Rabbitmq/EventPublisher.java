package com.prtsc.screenshotengine.Rabbitmq;

import com.google.gson.Gson;
import com.prtsc.screenshotengine.Models.ScreenshotCreated;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.stereotype.Component;

@Component
public class EventPublisher {
    static Logger log = LoggerFactory.getLogger(EventPublisher.class);
    private static RabbitTemplate rabbitTemplate;

    public EventPublisher(RabbitTemplate rabbitTemplate) {
        this.rabbitTemplate = rabbitTemplate;
    }

    public static void publishScreenshotToQueue(ScreenshotCreated screenshot) {
        Gson gson = new Gson();
        rabbitTemplate.convertAndSend("zcreenshot", "screenshot-created", gson.toJson(screenshot));
        log.info("Taken screenshot sent to screenshot-created queue.");
    }
}
